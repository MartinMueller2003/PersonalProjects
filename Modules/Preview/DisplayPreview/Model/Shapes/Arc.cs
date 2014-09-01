namespace VixenModules.Preview.DisplayPreview.Model.Shapes
{
	using System.Runtime.Serialization;

	[DataContract]
	internal class Arc : Shape
	{
		private double _strokeThickness;

		public Arc()
		{
			Initialize();
		}

		public override string Name
		{
			get { return "Arc"; }
		}

		public override ShapeType ShapeType
		{
			get { return ShapeType.Arc; }
		}

		public double StrokeThickness
		{
			get
			{
				if (_strokeThickness <= 0) {
					_strokeThickness = 5;
				}

				return _strokeThickness;
			}

			set
			{
				_strokeThickness = value;
				NotifyPropertyChanged("StrokeThickness");
			}
		}

		public override IShape Clone()
		{
			return new Arc();
		}

		private void Initialize()
		{
			_strokeThickness = 5;
		}

		[OnDeserializing]
		private void OnDeserializing(StreamingContext context)
		{
			Initialize();
		}
	}
}