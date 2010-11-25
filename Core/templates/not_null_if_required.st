$if(it.AssertNotNull)$
			if ($it.VarName$ == null)
				throw new ArgumentException("$it.Name$ can't be null");$\n$
$endif$