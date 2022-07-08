using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace ierarhie
{
    public class ControllerPersoane
    {
        private List<Persoana> list;

        public int Count
        {
            get => list.Count;
        }

        public ControllerPersoane()
        {
            list = new List<Persoana>();
        }

        public void citire()
        {
            StreamReader read = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "persoane.txt");

            String line = "";

            while ((line = read.ReadLine()) != null)
            {
                list.Add(new Persoana(line));
            }

            read.Close();
        }

        public Persoana get(int index)
        {
            return list[index];
        }
    }
}