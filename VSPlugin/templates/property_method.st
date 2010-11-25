$if(it.LazyInitializer)$
		$it.LazyInitializer.Annotations:annotation()$
		protected virtual $it.LazyInitializer.TypeName$ $it.LazyInitializer.Name$() 
		{
			if ($it.FieldName$ != null)
				return;

$if(it.DefaultValue)$
			$it.FieldName$ = $it.DefaultValue$;
$else$
			$it.FieldName$ = new $it.TypeName$();
$endif$
$if(it.CanListenTo)$
			Add$it.Name$Listeners($it.FieldName$);
$endif$
		}

$endif$
$if(it.Getter)$
		$it.Getter.Annotations:annotation()$
		protected virtual $it.Getter.TypeName$ $it.Getter.Name$()
		{
			$it.LazyInitializer:call()$
			return $it.FieldName$;
		}

$endif$
$if(it.Setter)$
		$it.Setter.Annotations:annotation()$
		protected virtual $it.Setter.TypeName$ $it.Setter.Name$($first(it.Setter.Parameters)$ $it.VarName$) 
		{
			$it:not_null_if_required()$
			if ($it.FieldName$ == $it.VarName$)
				return false;

			OnPropertyChanging(PROPERTIES.$it.DefineName$);

$if(it.CanListenTo)$
			Remove$it.Name$Listeners($it.VarName$);


$endif$
			$it.FieldName$ = $it.VarName$;

$if(it.CanListenTo)$
			Add$it.Name$Listeners($it.VarName$);


$endif$
			OnPropertyChanged(PROPERTIES.$it.DefineName$);

			return true;
		}

$if(it.CanListenTo)$
		private void Remove$it.Name$Listeners(object child)
		{
			if (child == null)
				return;

			var notifyPropertyChanging = child as INotifyPropertyChanging;
			if (notifyPropertyChanging != null)
				notifyPropertyChanging.PropertyChanging -= $it.Name$PropertyChangingEventHandler;

			var notifyChildPropertyChanging = child as INotifyChildPropertyChanging;
			if (notifyChildPropertyChanging != null)
				notifyChildPropertyChanging.ChildPropertyChanging -= $it.Name$ChildPropertyChangingEventHandler;

			var notifyPropertyChanged = child as INotifyPropertyChanged;
			if (notifyPropertyChanged != null)
				notifyPropertyChanged.PropertyChanged -= $it.Name$PropertyChangedEventHandler;

			var notifyChildPropertyChanged = child as INotifyChildPropertyChanged;
			if (notifyChildPropertyChanged != null)
				notifyChildPropertyChanged.ChildPropertyChanged -= $it.Name$ChildPropertyChangedEventHandler;
		}

$endif$
$endif$
$if(it.CanListenTo)$
		private void Add$it.Name$Listeners(object child)
		{
			if (child == null)
				return;

			var notifyPropertyChanging = child as INotifyPropertyChanging;
			if (notifyPropertyChanging != null)
				notifyPropertyChanging.PropertyChanging += $it.Name$PropertyChangingEventHandler;

			var notifyChildPropertyChanging = child as INotifyChildPropertyChanging;
			if (notifyChildPropertyChanging != null)
				notifyChildPropertyChanging.ChildPropertyChanging += $it.Name$ChildPropertyChangingEventHandler;

			var notifyPropertyChanged = child as INotifyPropertyChanged;
			if (notifyPropertyChanged != null)
				notifyPropertyChanged.PropertyChanged += $it.Name$PropertyChangedEventHandler;

			var notifyChildPropertyChanged = child as INotifyChildPropertyChanged;
			if (notifyChildPropertyChanged != null)
				notifyChildPropertyChanged.ChildPropertyChanged += $it.Name$ChildPropertyChangedEventHandler;
		}

		private void $it.Name$PropertyChangingEventHandler(object sender, PropertyChangingEventArgs e)
		{
			OnChildPropertyChanging(PROPERTIES.$it.DefineName$, sender, e);
		}

		private void $it.Name$ChildPropertyChangingEventHandler(object sender, ChildPropertyChangingEventArgs e)
		{
			OnChildPropertyChanging(PROPERTIES.$it.DefineName$, sender, e);
		}

		private void $it.Name$PropertyChangedEventHandler(object sender, PropertyChangedEventArgs e)
		{
			OnChildPropertyChanged(PROPERTIES.$it.DefineName$, sender, e);
		}

		private void $it.Name$ChildPropertyChangedEventHandler(object sender, ChildPropertyChangedEventArgs e)
		{
			OnChildPropertyChanged(PROPERTIES.$it.DefineName$, sender, e);
		}

$endif$
