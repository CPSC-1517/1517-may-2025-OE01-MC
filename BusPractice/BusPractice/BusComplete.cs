namespace BusPractice
{

using System;
using System.Collections.Generic;

public class BusComplete
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

        public BusComplete(string route, string busNumber, int capacity, double fare = 2.50)
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
    }
}
