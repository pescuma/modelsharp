using System.ComponentModel;

namespace $it.Package$
{
	$it.Annotations:annotation()$
	public class $it.Name$ : INotifyPropertyChanged
	{
		#region Field Name Defines
		public static class PROPERTIES
		{
			$it.Fields:define()$
			$it.Properties:define()$
		}
		#endregion

		$it.Fields:field()$

		$it.Properties:property()$

		#region INotifyPropertyChanged implementation

		public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
				handler(this, new PropertyChangedEventArgs(propertyName));
        }

		#endregion INotifyPropertyChanged implementation
	}
}