$if(it.LazyInitializer)$
		$it.LazyInitializer.Annotations:annotation()$
		protected virtual $it.LazyInitializer.TypeName$ $it.LazyInitializer.Name$() 
		{
			if ($it.FieldName$ != null)
				return;

$if(it.DefaultValue)$
			$it.FieldName$ = $it.DefaultValue$;
$else$
			$it.FieldName$ = new $it.TypeName$();$\n$
$endif$
$if(it.CanListenTo)$
			Add$it.Name$Listeners($it.FieldName$);
$endif$
$if(it.IsCollection)$
			Add$it.Name$ListListeners($it.FieldName$);
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
$if(it.IsCollection)$

		private void Add$it.Name$ListListeners(object child)
		{
			if (child == null)
				return;

			var notifyPropertyChanging = child as INotifyPropertyChanging;
			if (notifyPropertyChanging != null)
				notifyPropertyChanging.PropertyChanging += $it.Name$ListPropertyChangingEventHandler;

			var notifyPropertyChanged = child as INotifyPropertyChanged;
			if (notifyPropertyChanged != null)
				notifyPropertyChanged.PropertyChanged += $it.Name$ListPropertyChangedEventHandler;
$if(it.ContentsType.CanListenTo)$

			var notifyChildPropertyChanged = child as INotifyCollectionChanged;
			if (notifyChildPropertyChanged != null)
				notifyChildPropertyChanged.CollectionChanged += $it.Name$ListChangedEventHandler;
$endif$
		}

		private void $it.Name$ListPropertyChangingEventHandler(object sender, PropertyChangingEventArgs e)
		{
			if (e.PropertyName != $it.TypeName$.PROPERTIES.ITEMS)
				return;

			OnPropertyChanging(PROPERTIES.$it.DefineName$);
		}

		private void $it.Name$ListPropertyChangedEventHandler(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName != $it.TypeName$.PROPERTIES.ITEMS)
				return;

			OnPropertyChanged(PROPERTIES.$it.DefineName$);
		}

$if(it.ContentsType.CanListenTo)$
		private void $it.Name$ListChangedEventHandler(object sender, NotifyCollectionChangedEventArgs e)
		{
			switch (e.Action)
			{
				case NotifyCollectionChangedAction.Add:
				case NotifyCollectionChangedAction.Remove:
				case NotifyCollectionChangedAction.Replace:
					
					if ((e.OldItems == null || e.OldItems.Count == 0) 
							&& (e.NewItems == null || e.NewItems.Count == 0))
						throw new InvalidOperationException();

					if (e.OldItems != null)
						foreach (var item in e.OldItems)
							Remove$it.Name$ItemListeners(item);

					if (e.NewItems != null)
						foreach (var item in e.NewItems)
							Add$it.Name$ItemListeners(item);

					break;
				case NotifyCollectionChangedAction.Move:
					// Do nothing
					break;
				default:
					// NotifyCollectionChangedAction.Reset: The list should not fire this or 
					// we can't control the items
					throw new InvalidOperationException();
			}
		}

		private void Remove$it.Name$ItemListeners(object child)
		{
			if (child == null)
				return;

			var notifyPropertyChanging = child as INotifyPropertyChanging;
			if (notifyPropertyChanging != null)
				notifyPropertyChanging.PropertyChanging -= $it.Name$ItemPropertyChangingEventHandler;

			var notifyChildPropertyChanging = child as INotifyChildPropertyChanging;
			if (notifyChildPropertyChanging != null)
				notifyChildPropertyChanging.ChildPropertyChanging -= $it.Name$ItemChildPropertyChangingEventHandler;

			var notifyPropertyChanged = child as INotifyPropertyChanged;
			if (notifyPropertyChanged != null)
				notifyPropertyChanged.PropertyChanged -= $it.Name$ItemPropertyChangedEventHandler;

			var notifyChildPropertyChanged = child as INotifyChildPropertyChanged;
			if (notifyChildPropertyChanged != null)
				notifyChildPropertyChanged.ChildPropertyChanged -= $it.Name$ItemChildPropertyChangedEventHandler;
		}

		private void Add$it.Name$ItemListeners(object child)
		{
			if (child == null)
				return;

			var notifyPropertyChanging = child as INotifyPropertyChanging;
			if (notifyPropertyChanging != null)
				notifyPropertyChanging.PropertyChanging += $it.Name$ItemPropertyChangingEventHandler;

			var notifyChildPropertyChanging = child as INotifyChildPropertyChanging;
			if (notifyChildPropertyChanging != null)
				notifyChildPropertyChanging.ChildPropertyChanging += $it.Name$ItemChildPropertyChangingEventHandler;

			var notifyPropertyChanged = child as INotifyPropertyChanged;
			if (notifyPropertyChanged != null)
				notifyPropertyChanged.PropertyChanged += $it.Name$ItemPropertyChangedEventHandler;

			var notifyChildPropertyChanged = child as INotifyChildPropertyChanged;
			if (notifyChildPropertyChanged != null)
				notifyChildPropertyChanged.ChildPropertyChanged += $it.Name$ItemChildPropertyChangedEventHandler;
		}

		private void $it.Name$ItemPropertyChangingEventHandler(object sender, PropertyChangingEventArgs e)
		{
			OnChildPropertyChanging(PROPERTIES.$it.DefineName$, sender, e);
		}

		private void $it.Name$ItemChildPropertyChangingEventHandler(object sender, ChildPropertyChangingEventArgs e)
		{
			OnChildPropertyChanging(PROPERTIES.$it.DefineName$, sender, e);
		}

		private void $it.Name$ItemPropertyChangedEventHandler(object sender, PropertyChangedEventArgs e)
		{
			OnChildPropertyChanged(PROPERTIES.$it.DefineName$, sender, e);
		}

		private void $it.Name$ItemChildPropertyChangedEventHandler(object sender, ChildPropertyChangedEventArgs e)
		{
			OnChildPropertyChanged(PROPERTIES.$it.DefineName$, sender, e);
		}

$endif$
$endif$