namespace BusPractice
{

using System;
using System.Collections.Generic;

public class Bus
    {
        private string _Route;
        private string _BusNumber;
        private int _Capacity;
        private double _Fare;

        public string Route
        {
            get => _Route;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Route cannot be null or empty.");
                _Route = value;
            }
        }

        public string BusNumber
        {
            get => _BusNumber;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("BusNumber cannot be null or empty.");
                _BusNumber = value;
            }
        }

        public int Capacity
        {
            get => _Capacity;
            private set
            {
                if (value <= 0)
                    throw new ArgumentException("Capacity must be greater than zero.");
                _Capacity = value;
            }
        }

        public double Fare
        {
            get => _Fare;
            private set
            {
                if (value < 0)
                    throw new ArgumentException("Fare cannot be negative.");
                _Fare = value;
            }
        }

        public List<string> Stops
        {
            get;
            private set;
        }

        public Bus(string route, string busNumber, int capacity, double fare = 2.50)
        {
            Route = route.Trim();
            BusNumber = busNumber.Trim();
            Capacity = capacity;
            Fare = fare;
            Stops = new List<string>();
        }

        public void AddStop(string stop)
        {
            if (string.IsNullOrWhiteSpace(stop))
                throw new ArgumentException("Stop cannot be null or empty.");

            Stops.Add(stop);
        }

        public void RemoveStop(string stop)
        {
            if (string.IsNullOrWhiteSpace(stop))
                throw new ArgumentException("Stop cannot be null or empty.");

            Stops.Remove(stop);
        }

        public override string ToString()
        {
            return $"{Route},{BusNumber},{Capacity},{Fare},{string.Join(";", Stops)}";
        }

        public static Bus Parse(string csvLine)
        {
            if (string.IsNullOrWhiteSpace(csvLine))
                throw new ArgumentException("CSV line cannot be null or empty.");

            List<string> parts = csvLine.Split(',').ToList();
            if (parts.Count < 5)
                throw new ArgumentException("CSV line must contain at least 5 parts.");

            string route = parts[0].Trim();
            string busNumber = parts[1].Trim();
            int capacity = -1;
            double fare = 2.5;

            try
            {
                capacity = int.Parse(parts[2].Trim());
            }
            catch
            {
                throw new ArgumentException("Bad Capacity data, should be an integer");
            }

            try 
            { 
                fare = double.Parse(parts[3].Trim());
            }
            catch
            {
                throw new ArgumentException("Bad Fare data, should be a double");
            }

            List<string> stops = parts[4].Split(';').ToList();

            Bus bus = new Bus(route, busNumber, capacity, fare);
            
            foreach (string stop in stops)
            {
                bus.AddStop(stop.Trim());
            }

            return bus;
        }
    }
}
