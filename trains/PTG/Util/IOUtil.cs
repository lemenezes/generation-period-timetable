using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.IO;


namespace PeriodicTimetableGeneration
{
    /// <summary>
    /// Utility methods for Input/Output operations.
    /// </summary>
    public class IOUtil
    {

        #region Local Constants

        /// <summary>
        /// String "TypeOfTrain".
        /// </summary>
        public const String TYPE_OF_TRAIN = "TypeOfTrain";
        /// <summary>
        /// String "TrainLineNumber".
        /// </summary>
        public const String TRAIN_LINE_NUMBER = "TrainLineNumber";
        /// <summary>
        /// String "Period".
        /// </summary>
        public const String PERIOD =  "Period";
        /// <summary>
        /// String "Direction".
        /// </summary>
        public const String DIRECTION = "Direction";
        /// <summary>
        /// String "Provider".
        /// </summary>
        public const String PROVIDER = "Provider";
//        public const direction[] HEADER_PROPERTIES = { TYPE_OF_TRAIN, TYPE_OF_TRAIN,
//                                                      PERIOD,  DIRECTION, PROVIDER};
        /// <summary>
        /// Delimiter of fields used in input files.
        /// </summary>
        public const char DELIMITER = '#';
        /// <summary>
        /// Number of stop's details.
        /// </summary>
        public const int NUMBER_OF_STOP_DETAILS = 4;

        #endregion



        /// <summary>
        /// Writes the train line to file.
        /// </summary>
        public static void writeTrainLineToFile()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Reads the train line from file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>The train line.</returns>
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

            // original departure time
            Time originalDepartureTime = Time.MinValue;
            // createConstraintSet list of stops
            List<TrainStop> trainStops = createTrainStops(dataListStrings, line, out originalDepartureTime);
            // asign stops toStation the line_
            line.setTrainStops(trainStops);
            line.OriginalDeparture = originalDepartureTime;

            return line;
        }


        /// <summary>
        /// Creates the train stops.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="line">The line.</param>
        /// <returns>The train stops.</returns>
        private static List<TrainStop> createTrainStops(List<String[]> data, TrainLine line, out Time originalDepartureTime)
        {
            List<TrainStop> trainStops = new List<TrainStop>();
            TrainStationCache stationCache = TrainStationCache.getInstance();
            Int16 orderInLine = 0;
            String nameStation;
            Time departure;
            Time arrival;
            int kmFromStart;
            Time timeStart = Time.ToTime(data[0][2]);//Time.MinValue;
            // set original departure time
            originalDepartureTime = new Time(timeStart);

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

        /// <summary>
        /// Fills fields with information about train line from header.
        /// </summary>
        /// <param name="trainLine">The train line.</param>
        /// <param name="header">The header.</param>
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

        /// <summary>
        /// Reads the header information about the train line.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>The header.</returns>
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

        /// <summary>
        /// Deletes the header, first part of line's information.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>The data.</returns>
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


        /// <summary>
        /// Reads from file and parse the information separeted by delimiter.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>The data.</returns>
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
                //TODO: throw IOException??
            }
      
            return listString;
        }

        /// <summary>
        /// Gets the direction.
        /// </summary>
        /// <param name="direction">The direction.</param>
        /// <returns>The direction.</returns>
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
        /// Reads station's information from file.
        /// </summary>
        /// <returns>The stations.</returns>
        public static List<StationDetail> readTrainStationFromFile(String fileName)
        {
            const int MANDATORY = 2;
            const int ALL = 4;


            List<String[]> listOfStrings = readFromFile(fileName);
            List<StationDetail> stationDetails = new List<StationDetail>();

            if (listOfStrings == null) return null;
            if (listOfStrings.Count.Equals(0)) return stationDetails;

            // loop over all items in list of strings
            foreach (String[] strings in listOfStrings) 
            {
                //if there is only 2 items
                if (strings.Length.Equals(MANDATORY))
                {
                    stationDetails.Add(new StationDetail(strings[0], Convert.ToInt32(strings[1])));  
                }
                else if (strings.Length.Equals(ALL))
                {
                    StationDetail details = new StationDetail(strings[0], Convert.ToInt32(strings[1]));
                    if(strings[2] != "") 
                        details.MinimalTransferTime = Time.ToTime(Convert.ToInt32(strings[2]));
                    if (strings[3] != "")
                        details.Town = strings[3];
                    stationDetails.Add(details);
                }
            }

            return stationDetails;
        }

        public struct StationDetail 
        {

            public String StationName;// { get; set; }           
            public int Inhabitation;// { get; set; }
            public Time MinimalTransferTime;// { get; set; }
            public String Town;// { get; set; }


            public StationDetail(string stationName, int inhabitation) 
            {
                StationName = stationName;
                Inhabitation = inhabitation;
                MinimalTransferTime = Time.EmptyValue;
                Town = "";
            }
            public StationDetail(string stationName, int inhabitation, String name)
            {
                StationName = stationName;
                Inhabitation = inhabitation;
                MinimalTransferTime = Time.EmptyValue;
                Town = name;
            }
            public StationDetail(string stationName, int inhabitation, Time minimalTransferTime)
            {
                StationName = stationName;
                Inhabitation = inhabitation;
                MinimalTransferTime = minimalTransferTime;
                Town = "";
            }
            public StationDetail(string stationName, int inhabitation, Time minimalTransferTime, String name)
            {
                StationName = stationName;
                Inhabitation = inhabitation;
                MinimalTransferTime = minimalTransferTime;
                Town = name;
            }
        }

        /// <summary>
        /// Updates the field town category for stations from file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        public static void updateStationDetailsFromFile(String fileName)
        {
            List<StationDetail> stationDetails = IOUtil.readTrainStationFromFile(fileName);

            foreach (StationDetail stationDetail in stationDetails)
            {
                // if station exits in train station cache
                if (TrainStationCache.getInstance().doesStationExist(stationDetail.StationName))
                {
                    // find station in cache
                    TrainStation s = TrainStationCache.getInstance()
                        .getCacheContentOnName(stationDetail.StationName);
                    // copy inhabitation
                    s.Inhabitation = stationDetail.Inhabitation;
                    // update town category according inhabitation
                    s.updateTownCategory();

                    if (stationDetail.MinimalTransferTime != Time.EmptyValue)
                        s.MinimalTransferTime = stationDetail.MinimalTransferTime;

                    if (stationDetail.Town != "")
                        s.Town = stationDetail.Town;
                }
            }
        }

        /// <summary>
        /// Updates the ConnectedLines field for lines according relations define in file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        public static void updateConnectedLines(String fileName) 
        {
            // all train lines
            //List<TrainLine> lines = TrainLineCache.getInstance().getGroupOfConnections();


            // load all pairs in realtion
            List<String[]> listOfStrings = readFromFile(fileName);
            // create components
            List<HashSet<TrainLine>> components = createComponents(listOfStrings);

            // loop over all components
            foreach(HashSet<TrainLine> component in components)
            {
                // loop over all items in components
                foreach (TrainLine line in component) 
                {
                    // create list of items from component
                    List<TrainLine> itemsOfComponent = new List<TrainLine>(component);
                    // remove item to which will be this list assign
                    itemsOfComponent.Remove(line);

                    // assign list of connected lines
                    line.setConnectedLines(itemsOfComponent);
                }               
            }

        }

        /// <summary>
        /// Creates the components.
        /// </summary>
        /// <param name="listOfStrings">The list of strings.</param>
        /// <returns>The components</returns>
        private static List<HashSet<TrainLine>> createComponents(List<String[]> listOfStrings)
        {
            // create list of components
            List<HashSet<TrainLine>> components = new List<HashSet<TrainLine>>();


            // loop over all pair
            foreach (String[] strings in listOfStrings)
            {
                // if is not pair, continue
                if (!strings.Length.Equals(2)) continue;

                TrainLine item1 = TrainLineCache.getInstance().getCacheContentOnNumber(Convert.ToInt32(strings[0]));
                TrainLine item2 = TrainLineCache.getInstance().getCacheContentOnNumber(Convert.ToInt32(strings[1]));

                // both lines must exist
                if (item1 == null || item2 == null) continue;

                // set single components
                HashSet<TrainLine> component1 = new HashSet<TrainLine>();
                component1.Add(item1);
                HashSet<TrainLine> component2 = new HashSet<TrainLine>();
                component2.Add(item2);

                int foundBoth = 0;
                // find components
                foreach (HashSet<TrainLine> component in components)
                {
                    // find first component
                    if (component.Contains(item1))
                    {
                        component1 = component;
                        foundBoth++;
                    }
                    // find second component
                    if (component.Contains(item2))
                    {
                        component2 = component;
                        foundBoth++;

                    }
                    if (foundBoth == 2)
                        break;
                }

                // no compomenets exist, add first as the only one
                if (foundBoth == 0)
                {
                    components.Add(component1);
                }

                // if different, mergde them
                if (component1 != component2)
                {
                    // remove 2nd
                    components.Remove(component2);
                    component1.UnionWith(component2);
                }
            }
            return components;
        }
    }
}
