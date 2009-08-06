using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsFormsApplication1
{
    public class TrainLine
    {
        /// <summary>
        /// cislo vlakovej linky
        /// </summary>
        private int trainLineNumber;
        /// <summary>
        /// zviazane linky s touto linkou
        /// </summary>
        private int connectedTrainLines;
        /// <summary>
        /// zoznam stanic ktorymi linka prechadza
        /// </summary>
        private int trainStations;
        /// <summary>
        /// vlakove spoje, kt linka obsahuje
        /// </summary>
        private int containedTrainConnects;
    
        public TrainLine()
        {
            throw new System.NotImplementedException();
        }

        public int getTrainLineNumber()
        {
            throw new System.NotImplementedException();
        }

        public void addConnectedTrainLine()
        {
            throw new System.NotImplementedException();
        }

        public void getConnectedTrainLines()
        {
            throw new System.NotImplementedException();
        }

        public void getContainedTrainConnects()
        {
            throw new System.NotImplementedException();
        }

        public void addTrainConnect()
        {
            throw new System.NotImplementedException();
        }
    }
}
