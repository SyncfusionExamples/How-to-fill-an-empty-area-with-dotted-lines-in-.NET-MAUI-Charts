using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmptyAreaSample
{
    public class ViewModel
    {
        public ObservableCollection<Model> Data { get; set; }
        public ObservableCollection<Model> Data1 { get; set; }
        public ObservableCollection<Model> LineData { get; set; }

        public ObservableCollection<Model> NewData { get; set; }
        public bool IsEmpty {  get; set; }

        public ViewModel() 
        {
            NewData = new ObservableCollection<Model>();
            NewData.Add(new Model(new DateTime(2000,01,02), 10));
            NewData.Add(new Model(new DateTime(2000, 01, 03), 15));
            NewData.Add(new Model(new DateTime(2000, 01, 05), 11));
            NewData.Add(new Model(new DateTime(2000, 01, 07), 20));
            NewData.Add(new Model(new DateTime(2000, 01, 09), 09));

            Data = new ObservableCollection<Model>();
            Data1 = new ObservableCollection<Model>();
            LineData = new ObservableCollection<Model>();
            var date = new DateTime(2007, 08, 10);
            var random = new Random();
            for (int i = 0; i < 15; i++)
            {
                if (i == 3 || i == 10)
                {
                    Data.Add(new Model(date, double.NaN));
                    Data1.Add(new Model(date, double.NaN));
                }
                else
                {
                    Data.Add(new Model(date, random.Next(10, 30)));
                    Data1.Add(new Model(date, random.Next(10, 30)));                    
                }

                date= date.AddDays(1);
            }

            for(int i = 0;i<Data.Count;i++)
            {
                if (double.IsNaN(Data[i].Value))
                {
                    IsEmpty = true;
                }
                else
                {
                    IsEmpty = false;
                }

                if(IsEmpty)
                {
                    if (!double.IsNaN(Data[i-1].Value))
                    {
                        LineData.Add(new Model(Data[i - 1].Date, 0));
                        LineData.Add(new Model(Data[i - 1].Date, Data[i-1].Value + Data1[i-1].Value));
                    }
                    if (!double.IsNaN(Data[i+1].Value))
                    {
                        LineData.Add(new Model(Data[i + 1].Date, Data[i+1].Value + Data1[i+1].Value));
                        LineData.Add(new Model(Data[i + 1].Date, 0));
                        LineData.Add(new Model(Data[i + 1].Date, double.NaN));
                    }
                }
            }
        }

        
    }
}
