using UnityEngine;
using System.Collections;
using System.Collections.Generic;

    public class AmbList
    {

        public string name;
        public int points;

        public AmbList(string newName, string newPoints)
        {
            name = newName;
            int.TryParse(newPoints, out points);
        }
    }
    public class MusList
    {

        public string name;
        public int points;
        public string element;

        public MusList(string newName, string newPoints, string newElement)
        {
            name = newName;
            int.TryParse(newPoints, out points);
            element = newElement;
        }
    }
    public class TechList
    {

        public string name;
        public int points;
        public string element;
        public string description;

        public TechList(string newName, string newPoints, string newElement, string newDescription)
        {
            name = newName;
            int.TryParse(newPoints, out points);
            element = newElement;
            description = newDescription;
        }
    }
    public class AllList
    {

        public string name;
        public int points;
		public string type;

	public AllList(string newName, int newPoints, string newType)
        {
            name = newName;
            points = newPoints;
			type = newType;
        }
    }
