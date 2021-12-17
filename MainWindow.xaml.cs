using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace timesheet {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		public MainWindow () {
			InitializeComponent();

			List<Entry> items = new List<Entry>();

			items.Add(new Entry() { 
				Start = new EntryTime(new DateTime(2021, 5, 10, 8, 5, 0)), 
				End = new EntryTime(new DateTime(2021, 5, 10, 9, 35, 0)),
				Description = "Hello world"
			});
			items.Add(new Entry() { 
				Start = new EntryTime(new DateTime(2021, 5, 11, 8, 5, 0)), 
				End = new EntryTime(new DateTime(2021, 5, 11, 8, 6, 30)),
				Description = "This is a description"
			});
			items.Add(new Entry() { 
				Start = new EntryTime(new DateTime(2021, 5, 12, 8, 5, 0)), 
				End = new EntryTime(new DateTime(2021, 5, 14, 8, 5, 0)),
				Description = "Hello world"
			});
			items.Add(new Entry() { 
				Start = new EntryTime(new DateTime(2021, 5, 16, 12, 30, 0)),
				Description = "This is a really long description hello world"
			});

			Timesheet.ItemsSource = items;
			System.Diagnostics.Trace.WriteLine(Timesheet.Items[0]);

		}
	}

	public class Entry {

		public EntryTime Start { get; set; } = null;
		public EntryTime End { get; set; } = null;
		public string Description { get; set; } = "";
		public string Dates => GetDateString();
		public string Duration => GetDurationString();

		private string GetDateString () {

			string ret = Start.Date;

			if (End == null)
				return ret + " - Now";

			if (Start.SameDayAs(End))
				return ret;

			return ret + " - " + End.Date;

		}

		private string GetDurationString () {

			EntryTime end = End == null ? new EntryTime(DateTime.Now) : End;

			double duration = Start.HourDelta(end);
			string unit = "hours";
			if (duration < 1) {
				duration = Start.MinuteDelta(end);
				unit = "minutes";
			}

			return string.Format("{0:0.00} {1}", duration, unit);

		}
	}

	public class EntryTime {

		private readonly DateTime _value;

		public string Date => _value.ToString("d");
		public string Time => _value.ToString("t");

		public EntryTime (DateTime value) {
			_value = value;
		}

		public double HourDelta (EntryTime end) {
			return (end._value - _value).TotalHours;
		}

		public double MinuteDelta (EntryTime end) {
			return (end._value - _value).TotalMinutes;
		}

		public bool SameDayAs (EntryTime other) {
			return other._value.Date == _value.Date;
		}

	}

}
