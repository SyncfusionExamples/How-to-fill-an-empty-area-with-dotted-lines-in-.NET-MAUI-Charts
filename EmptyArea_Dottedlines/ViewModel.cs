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
        public ObservableCollection<Model> Data1 { get; set; }
        public ObservableCollection<Model> Data2 { get; set; }
        public ObservableCollection<Model> LineData { get; set; }

        public bool IsEmpty { get; set; }

        public ViewModel() 
        {            
            Data1 = new ObservableCollection<Model>();
            Data2 = new ObservableCollection<Model>();
            LineData = new ObservableCollection<Model>();
            
            var date = new DateTime(2023, 08, 10);
            var random = new Random();
            for (int i = 0; i < 15; i++)
            {
                if (i == 3 || i == 10)
                {
                    Data1.Add(new Model(date, double.NaN));
                    Data2.Add(new Model(date, double.NaN));
                }
                else
                {
                    Data1.Add(new Model(date, random.Next(10, 30)));
                    Data2.Add(new Model(date, random.Next(10, 30)));                    
                }

                date= date.AddDays(1);
            }

            for(int i = 0;i<Data1.Count;i++)
            {
                if (double.IsNaN(Data1[i].Value))
                {
                    IsEmpty = true;
                }
                else
                {
                    IsEmpty = false;
                }

                if(IsEmpty)
                {
                    if (!double.IsNaN(Data1[i-1].Value))
                    {
                        LineData.Add(new Model(Data1[i - 1].Date, 0));
                        LineData.Add(new Model(Data1[i - 1].Date, Data1[i-1].Value + Data2[i-1].Value));
                    }
                    if (!double.IsNaN(Data1[i+1].Value))
                    {
                        LineData.Add(new Model(Data1[i + 1].Date, Data1[i+1].Value + Data2[i+1].Value));
                        LineData.Add(new Model(Data1[i + 1].Date, 0));
                        LineData.Add(new Model(Data1[i + 1].Date, double.NaN));
                    }
                }
            }
        }

        
    }
}
