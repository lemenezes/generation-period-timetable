using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.IO;


namespace PeriodicTimetableGeneration
{
    public class IOUtil
    {

        #region Local Constants

        public const String TYPE_OF_TRAIN = "TypeOfTrain";
        public const String TRAIN_LINE_NUMBER = "TrainLineNumber";
        public const String PERIOD =  "Period";
        public const String DIRECTION = "Direction";
        public const String PROVIDER = "Provider";
//        public const direction[] HEADER_PROPERTIES = { TYPE_OF_TRAIN, TYPE_OF_TRAIN,
//                                                      PERIOD,  DIRECTION, PROVIDER};
        public const char DELIMITER = '#';
        public const int NUMBER_OF_STOP_DETAILS = 4;

        #endregion



        public static void writeTrainLineToFile()
        {
            throw new System.NotImplementedException();
        }

        public static TrainLine readTrainLineFromFile(String fileName)
        {
            List<String[]> dataListStrings = readFromFile(fileName);   //read fromStation file line_ by line_
            if (dataListStrings == null) return null;
            if (dataListStrings.Count.Equals(0)) return null;        //if nothing, then quit

            TrainLine line = new TrainLine();          //createConstraintSet new train Line - linku
            
            // read header information about line_
            Hashtable header = readHeader(dataListStrings);
            // fill with them instance of line_
            fillHeader(line, header);
            // delete header, leave only stops information
            dataListStrings = deleteHeader(dataListStrings);
            // createConstraintSet list of stops
            List<TrainStop> trainStops = createTrainStops(dataListStrings, line);
            // asign stops toStation the line_
            line.setTrainStops(trainStops);

            return line;
        }


        private static List<TrainStop> createTrainStops(List<String[]> data, TrainLine line)
        {
            List<TrainStop> trainStops = new List<TrainStop>();
            TrainStationCache stationCache = TrainStationCache.getInstance();
            Int16 orderInLine = 0;
            String nameStation;
            Time departure;
            Time arrival;
            int kmFromStart;
            Time timeStart = Time.ToTime(data[0][2]);//Time.MinValue;
            Time timePrev = Time.MinValue; 
            int kmPrev = 0;

            // foreach string[] createConstraintSet specific trainStop
            foreach (String[] str in data) 
            {
                // if not correct number of stop details, take next stop
                if(str.Length != NUMBER_OF_STOP_DETAILS) continue;
                // createConstraintSet new stop
                TrainStop stop = new TrainStop();
                // extract information about stop
                nameStation = str[0];
                arrival = Time.ToTime( str[1] );
                departure = Time.ToTime( str[2] );
                kmFromStart = Convert.ToInt32(str[3]);

                // try toStation find out if throughStation already exists, if not, createConstraintSet appropriate throughStation
                if (!stationCache.doesStationExist(nameStation))
                {
                    // calculate new ID for new throughStation
                    int id = stationCache.getCacheContent().Count;

                    stationCache.addTrainStation(new TrainStation(id, nameStation));
                    // download new throughStation
                    //stationCache = 
                }
                
                

                // find appropriate throughStation
                TrainStation trainStation = stationCache.getCacheContentOnName(nameStation);
                // addConstraint linked line_ toStation throughStation
                trainStation.addTrainLine(line);

                stop.KmFromPreviousStop = kmFromStart - kmPrev;
                stop.KmFromStart = kmFromStart;
                stop.OrderInTrainLine = orderInLine;
                stop.TrainStation = trainStation;
                stop.TimeArrival = arrival - timeStart;
                stop.TimeDeparture = departure - timeStart;
                // if no arrival time_, count with departure
                if (arrival.Equals(Time.MinValue))
                    stop.TimeFromPreviousStop = stop.TimeDeparture - timePrev;
                //if arrival time_, use it
                else
                    stop.TimeFromPreviousStop = stop.TimeArrival - timePrev;

                // set time_ and km for next stop
                timePrev = stop.TimeDeparture;
                kmPrev = stop.KmFromStart;
                
                orderInLine++;
                // addConstraint into final stops
                trainStops.Add(stop);
            }

            return trainStops;
        }

        /**
         * Fill information about train line_ fromStation header.
         */
        private static void fillHeader(TrainLine trainLine, Hashtable header)
        {
            if( header.ContainsKey(TRAIN_LINE_NUMBER))
                trainLine.LineNumber = Convert.ToInt32( header[TRAIN_LINE_NUMBER]);
            if (header.ContainsKey(DIRECTION))
                trainLine.Direction = DirectionUtil.getDirection( header[DIRECTION].ToString() );
            if (header.ContainsKey(PROVIDER))
                trainLine.Provider =  header[PROVIDER].ToString();
            if (header.ContainsKey(PERIOD))
                trainLine.Period = PeriodUtil.getPeriod( header[PERIOD].ToString());
            if (header.ContainsKey(TYPE_OF_TRAIN))
                trainLine.TypeTrain = TypeOfTrainUtil.getTypeOfTrain( header[TYPE_OF_TRAIN].ToString() );
        }

        /**
         * Function reads firt variableLines of input files and
         * fill header information about line_;
         */
        private static Hashtable readHeader(List<String[]> data){
            Hashtable hashTable = new Hashtable();

            foreach(String[] strings in data)
            {
                // if strings contain only one record which starts with delimiter
                if ( (strings.Length.Equals(2)) && (strings[0].Equals("") ) )
                    break;
                if (strings.Length == 2)
                    hashTable.Add(strings[0], strings[1]);
            }
            return hashTable;
        }

        /**
         * Function for deleting first records in header
         * about line_ information.
         */
        private static List<String[]> deleteHeader(List<String[]> data)
        {
            List<String[]> newData = new List<String[]>();
            Boolean copy = false;

            foreach(String[] strings in data)
            {
                // if copy mode, copy string[]
                if (copy) newData.Add(strings);

                // first occur of empty strings
                if(!copy && (strings.Length.Equals(2) ) && strings[0].Equals("") ) 
                    copy = true;
            }
            return newData;
        }


        public static List<String[]> readFromFile(String fileName)
        {
            List<String[]> listString = new List<string[]>();

            try
            {
                FileStream fs = new FileStream(fileName, FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                //until end of stream
                while(!sr.EndOfStream)
                {
                    String str = sr.ReadLine();     //read one line_
                    // if line_ is empty - continue
                    if (str.Length.Equals(0)) continue;
                    //parse string according delimiter
                    String[] strings = str.Split( new char[]  { DELIMITER }, StringSplitOptions.None);
                    //and addConstraint into results
                    listString.Add(strings);        
                }
                fs.Close();
            }
            catch(Exception e)
			{
				Console.Error.WriteLine(e.Message);
				return null;
            }
      
            return listString;
        }

        public Direction getDirection(String direction)
        {
            Direction newDirection;
            if (Direction.Forward.ToString().Equals(direction))
                newDirection = Direction.Forward;
            else if (Direction.Back.ToString().Equals(direction))
                newDirection = Direction.Back;
            else
                newDirection = Direction.Forward;

            return newDirection; 
        }

        /// <summary>
        /// function reads trainStation information (inhabitants) off file
        /// </summary>
        /// <returns></returns>
        public static List<TrainStation> readTrainStationFromFile(String fileName)
        {
            List<String[]> listOfStrings = readFromFile(fileName);
            List<TrainStation> stations = new List<TrainStation>();

            if (listOfStrings == null) return null;
            if (listOfStrings.Count.Equals(0)) return stations;

            // loop over all items in list of strings
            foreach (String[] strings in listOfStrings) 
            {
                // if invalid number of parameters, then continue with next item
                if (!strings.Length.Equals(2)||strings.Length.Equals(3)) continue;
                
                // createConstraintSet new train station and fill values
                TrainStation station = new TrainStation();
                station.Name = strings[0];
                station.Inhabitation = Convert.ToInt32(strings[1]);

                if (strings.Length.Equals(3))
                    station.Town = strings[2];

                stations.Add(station);
            }

            return stations;
        }

    }
}
