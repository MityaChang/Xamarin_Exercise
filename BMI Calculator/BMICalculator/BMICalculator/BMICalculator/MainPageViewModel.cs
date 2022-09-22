using System;
using System.ComponentModel;

namespace BMICalculator
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private double height = 180;
        private double weight = 50;
        private const double STEP = 1.0;

        public event PropertyChangedEventHandler PropertyChanged;

        public double Height
        {
            get => height;
            set
            {
                height = NEXTSTEP(value);
                RaisePropertyChanged(nameof(Bmi));
                RaisePropertyChanged(nameof(Classification));
            }
        }
        public double Weight
        {
            get => weight;
            set
            {
                weight = NEXTSTEP(value);
                RaisePropertyChanged(nameof(Bmi));
                RaisePropertyChanged(nameof(Classification));
            }
        }

        public double Bmi => Math.Round(Weight / Math.Pow(Height / 100, 2), 2);


        public string Classification
        {
            get
            {
                if (Bmi < 18.5)
                    return "You are underwight";
                else if (Bmi < 25)
                    return "You are normal weight";
                else if (Bmi < 30)
                    return "You are overweight";
                else
                    return "You are obese";
            }
        }

        private double NEXTSTEP(double value)
        {
            return Math.Round(value / STEP) * STEP;
        }
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }

}


