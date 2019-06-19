using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class Charts : MonoBehaviour
{
    private class LineSet
    {
        List<ChartElement> pointsList;
        public UIMeshLine lineMesh;

        //construtor da classe
        public LineSet(UIMeshLine mLine)
        {
            lineMesh = mLine;
            pointsList = new List<ChartElement>();
        }

        //adiciona novos pontos à estrutura de dados
        public void AddPoint(ChartElement newPoint)
        {
            pointsList.Add(newPoint);
        }

        //funcao para mudar a cor dos marcadores e da linha
        public void SetColor(Color color)
        {
            //define a cor da linha
            lineMesh.color = color;
            //define a cor dos marcadores, um a um
            foreach (ChartElement marker in pointsList)
            {
                marker.element.color = color;
            }
        }
    }

    //define variaveis
    public ChartElement elementsHolder;
    public ChartElement barStack;
    public ChartElement marker;
    public ChartElement line;
    public RectTransform content;

    //pode aumentar ou diminuir o tamanho dos items
    public int itemSize = 500;

    [Header("1: grafico 1; 2: grafico 2; 3: grafico 3")]
    public int chartType = 0;

    public Color[] colors;

    void SetContentWidth(int totalItems)
    {
        int newWidth = totalItems * itemSize;
        Vector2 newSize = content.sizeDelta + (Vector2.right * newWidth);
        content.sizeDelta = newSize;
    }

    int[] DefineMax(Dictionary<string, List<int>> inputData, string chartType)
    {

        int maxValue = 0;
        int maxCount = 0;
        int tempVal, tempCount;

        if (chartType == "bar")
        {
            //determina a maior serie de dados para ajustar a escala do eixo
            foreach (KeyValuePair<string, List<int>> dataSeries in inputData)
            {
                //armazena a soma dos dados da série
                tempVal = dataSeries.Value.Sum();

                //compara com o maior valor armazenado ate agora
                if (tempVal > maxValue)
                {
                    //se for maior, armazena a nova maior soma
                    maxValue = tempVal;
                }
            }
        }
        else if (chartType == "line")
        {
            foreach (KeyValuePair<string, List<int>> dataSeries in inputData)
            {
                //armazena a soma dos dados da série
                tempVal = dataSeries.Value.Max();
                tempCount = dataSeries.Value.Count();

                //compara com o maior valor armazenado ate agora
                if (tempVal > maxValue)
                {
                    //se for maior, armazena o novo valor
                    maxValue = tempVal;
                }
                if (tempCount > maxCount)
                {
                    maxCount = tempCount;
                }
            }
        }

        return new[] { maxValue, maxCount };
    }

    void DisplayBarChart(Dictionary<string, List<int>> inputData, List<string> labels = null, int[] setMax = null)
    {

        //define variaveis
        List<int> values;
        float normalizedValue, yPosition;
        ChartElement stack;
        ChartElement newBarHolder;
        float chartHeight;
        int counter;
        int[] maxValues;
		int maxLoop;

        if (setMax != null)
        {
            maxValues = setMax;
        }
        else
        {
            maxValues = DefineMax(inputData, "bar");
        }
         
        counter = 0;
        if (chartType == 1)
        {
            SetContentWidth(inputData.Count);
        }

        //define o tamanho da area vertical util do grafico (dependendo do tamanho da tela e tal)
        chartHeight = GetComponent<RectTransform>().rect.height;

        //inicia o desenho do grafico
        foreach (KeyValuePair<string, List<int>> dataSeries in inputData)
        {
            yPosition = 0f;

            //pega a serie de dados
            values = dataSeries.Value;

            //instancia uma nova serie (barHolder)
            newBarHolder = Instantiate(elementsHolder, transform) as ChartElement;
            //coloca valor da legenda
            if (labels == null)
            {
                newBarHolder.seriesLabel.text = dataSeries.Key;
            }
            else
            {
                newBarHolder.seriesLabel.text = labels[counter];
            }
   			
			//gambiarra do iPad (setima barra)
			if (labels != null) {
				maxLoop = values.Count;
			} else {
				maxLoop = 6;
			}

            //varre todos os pontos de dados da serie atual
            //for (int i = 0; i < values.Count; i++)
			for (int i = 0; i < maxLoop; i++)
            {
                //normaliza o valor do ponto atual (multiplica por 0.95 pra dar uma folga no topo do grafico)
                normalizedValue = (float)values[i] * 0.95f / (float)maxValues[0];

                //cria uma nova barra/camada para cada ponto de dados na serie
                stack = Instantiate(barStack, newBarHolder.transform) as ChartElement;

                //redimensiona a barra proporcionalmente
                stack.elementRect.sizeDelta = new Vector2(stack.elementRect.sizeDelta.x, chartHeight * normalizedValue);
                //desloca a camada da barra para cima
                stack.transform.Translate(Vector3.up * yPosition * chartHeight);

                //muda a cor da barra (fica repetindo a lista de cores)
                stack.element.color = colors[i % colors.Length];

                //define a legenda de dados da barra
                if (values[i] == 0)
                {
                    stack.elementLabel.text = "N/A";
                }
                else
                {
                    stack.elementLabel.text = values[i].ToString();
                }

                //verifica a posicao da label do valor
                if (stack.elementRect.sizeDelta.y < 14f)
                {
                    stack.elementLabel.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0f);
                    stack.elementLabel.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                }

                //incrementa posicao Y para empilhar as proximas barras
                yPosition += normalizedValue;
            }
            counter++;
        }
    }

    void DisplayLineChart(Dictionary<string, List<int>> inputData, List<string> dates)
    {
        //define variaveis
        List<int> values;
        float normalizedValue, chartHeight, chartWidth, value, normalizedX;
        ChartElement lineMarker, linePrefab;
        ChartElement newSeriesHolder;
        RectTransform markerRect, chartRect;
        int i;

        //cria a estrutura de dados que vai receber as linhas (e os pontos)
        Dictionary<string, LineSet> seriesLines = new Dictionary<string, LineSet>();

        //inicia a estrutura de dados para receber os pontos do grafico
        List<string> keyList = new List<string>(inputData.Keys);

        //varre a estrutura de dados para determinar alguns valores de interesse
        int[] maxValues = DefineMax(inputData, "line");

        //cria uma estrutura de dados para cada série de dados
        for (i = 0; i < inputData.Count; i++)
        {
            linePrefab = Instantiate(line, transform.parent) as ChartElement;
            linePrefab.transform.localPosition = Vector3.zero;
            linePrefab.elementRect.offsetMin = new Vector2(9f, 30f);
            seriesLines.Add(keyList[i], new LineSet(linePrefab.lineMesh));
        }

        //para otimizar a execucao, guarda o RectTransform do marcador em uma variavel
        //verticalLayout = transform.parent.GetComponentInParent<VerticalLayoutGroup>();

        markerRect = marker.GetComponent<RectTransform>();
        chartRect = GetComponent<RectTransform>();
        //define o tamanho da area util do grafico

        chartHeight = chartRect.rect.height - markerRect.sizeDelta.y;
        chartWidth = chartRect.rect.width;

        //define posicao inicial dos elementos no eixo X
        normalizedX = (chartWidth / (maxValues[1] * 2) - markerRect.sizeDelta.x);

        //inicia o desenho do grafico
        for (i = 0; i < maxValues[1]; i++)
        {
            //instancia uma nova serie (elementsHolder)
            newSeriesHolder = Instantiate(elementsHolder, transform) as ChartElement;
            //coloca valor da legenda
            newSeriesHolder.seriesLabel.text = dates[i];

            //cria o iésimo ponto de cada série
            foreach (KeyValuePair<string, List<int>> dataSeries in inputData)
            {

                //pega a serie de dados
                values = dataSeries.Value;

                //check de seguranca caso alguma serie de dados tenha menos pontos que a maior serie de dados
                if (i < values.Count)
                {
                    value = values[i];
                }
                else
                {
                    value = 0f;
                }
                //normaliza o valor do ponto atual (multiplica por 0.95 pra dar uma folga no topo do grafico)
                normalizedValue = value * 0.95f / (float)maxValues[0];

                //cria um novo marcador para cada ponto de dados na serie
                lineMarker = Instantiate(marker, newSeriesHolder.transform) as ChartElement;

                //desloca o ponto para a posicao apropriada
                lineMarker.transform.Translate(Vector3.up * chartHeight * normalizedValue);

                //define a legenda de dados da barra
                lineMarker.elementLabel.text = value.ToString();

                //adiciona o ponto à linha e o elemento do marcador à estrutura de dados
                //seriesLines[dataSeries.Key].lineMesh.points.Add(new LinePoint(new Vector2(normalizedX, lineMarker.transform.position.y - markerRect.sizeDelta.y / 2)));
                Vector3 localCoordinates = line.transform.TransformPoint(new Vector3(normalizedX, lineMarker.transform.position.y - markerRect.sizeDelta.y, line.transform.position.z));
                //seriesLines[dataSeries.Key].lineMesh.points.Add(new LinePoint(new Vector2(normalizedX, lineMarker.transform.position.y - markerRect.sizeDelta.y / 2)));
                seriesLines[dataSeries.Key].lineMesh.points.Add(new LinePoint(new Vector2(normalizedX, localCoordinates.y - 350f)));
                seriesLines[dataSeries.Key].AddPoint(lineMarker);
            }
            //incrementa a posicao no eixo X para o desenho da linha
            normalizedX += chartWidth / maxValues[1];
        }

        i = 0;
        //define as cores das linhas e marcadores
        foreach (KeyValuePair<string, List<int>> dataSeries in inputData) { 
            seriesLines[dataSeries.Key].SetColor(colors[i % colors.Length]);
            i++;
        }
    }

    List<string> SplitPPref(string pPref, bool isDate = false, char separator = '_')
    {
        List<string> data;
        string[] info;

        if (!isDate)
        {
            info = PlayerPrefs.GetString(pPref).Split(separator);
            data = new List<string>(info);
        }
        else
        {
            data = new List<string>();
            foreach(string item in PlayerPrefs.GetString(pPref).Split(separator))
            {
                //data.Add(item.Substring(0, item.Length - 12));
                data.Add(item);
            }
        }

        return data;
    }

    Dictionary<string, List<int>> ParsePPref (List<string> pPrefs)
    {
        Dictionary<string, List<int>> data = new Dictionary<string, List<int>>();
        List<int> tempInt;

        //varre todas as pPrefs da lista predefinida
        foreach (string pPref in pPrefs)
        {
            //zera a lista temporaria de ints
            tempInt = new List<int>();
            //passa os strings para int e separa os elementos da pPref
            foreach (string item in SplitPPref(pPref))
            {
                if (item != null) {
                    if (item == "")
                    {
                        tempInt.Add(0);
                    }
                    else
                    {
                        tempInt.Add(int.Parse(item));
                    }
                }
            }
            //adiciona na estrutura de dados do grafico
            data.Add(pPref.Split(' ')[1], tempInt);
        }

        return data;
    }

    void Start()
    {
        Canvas.ForceUpdateCanvases();

        if (chartType == 1){
            //Gráfico 1: baseado no quiz
            List<string> dateInfo = SplitPPref("Progress Date", true);
            List<string> pPrefsQuiz = new List<string> { "Progress Core", "Progress Vision", "Progress Mission", "Progress Interactions", "Progress Structure", "Progress Synergy" };

            Dictionary<string, List<int>> dataTemp = ParsePPref(pPrefsQuiz);

            SortedDictionary<string, List<int>> data1 = new SortedDictionary<string, List<int>>();

            for (int i = 0; i < dateInfo.Count; i++)
            {
                data1.Add(dateInfo[i], new List<int>());
                for (int a = 0; a < pPrefsQuiz.Count; a++)
                {
                    data1[dateInfo[i]].Add(dataTemp[pPrefsQuiz[a].Split(' ')[1]][i]);
                }
            }

            //cria dicionario ordenado automaticamente
            Dictionary<string, List<int>> data1Sorted = new Dictionary<string, List<int>>(data1);

            DisplayBarChart(data1Sorted);

        }
        else if(chartType == 2){
            //Gráfico 2: baseado no 'gather energy'
            List<string> dateInfo = SplitPPref("Gather Date", true);

            List<string> pPrefsGather = new List<string> { "Progress Gather" };//, "Gather Core", "Gather Vision", "Gather Mission", "Gather Interactions", "Gather Structure", "Gather Synergy" };

            //cria estrutura que ordena os elementos automaticamente
            SortedDictionary<string, List<int>> data2 = new SortedDictionary<string, List<int>>(ParsePPref(pPrefsGather));
            Dictionary<string, List<int>> data2Sorted = new Dictionary<string, List<int>>(data2);

            DisplayLineChart(data2Sorted, dateInfo);

        }
        else if (chartType == 3){
            //Gráfico 3: moods

            List<string> dateInfo;

            List<string> pPrefsMoods = new List<string> { "Progress Moods" };
            List<string> dateInfoMoods;
            int i;

            i = 0;
            
            SortedDictionary<string, List<int>> data3 = new SortedDictionary<string, List<int>>(ParsePPref(pPrefsMoods));

            Dictionary<string, List<int>> data3Sorted;

            if (PlayerPrefs.HasKey("Mood Dates"))
            {
                //linha original, que pega as datas dos Moods
                dateInfoMoods = SplitPPref("Mood Dates", true);

                //funcao alterada para usar as mesmas datas do quiz
                dateInfo = SplitPPref("Progress Date", true);

            foreach (string date in dateInfo)
                {
                    if (dateInfoMoods.Contains(date)){
                        data3.Add(date, new List<int> { data3["Moods"][i] });
                        i++;
                    }
                    else
                    {
                        data3.Add(date, new List<int> { 0 });
                    }
                }
                i = 0;
                foreach (string date in dateInfoMoods)
                {
                    if (!dateInfo.Contains(date))
                    {
                        data3.Add(date, new List<int> { data3["Moods"][i] });
                        i++;
                    }
                }
                data3.Remove("Moods");
            }
            else
            {
                dateInfoMoods = new List<string>();
                dateInfo = new List<string>();
            }

            data3Sorted = new Dictionary<string, List<int>>(data3);
            DisplayBarChart(data3Sorted, dateInfo, new int[1] { 5 });


        }
    }
}
