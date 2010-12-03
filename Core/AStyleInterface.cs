using System;
using System.Runtime.InteropServices;

namespace org.pescuma.ModelSharp.Core
{
	/// AStyleInterface contains methods to call the Artistic Style formatter.
	public class AStyleInterface
	{
		// Cannot use string as a return value because Mono runtime will attempt to
		// free the returned pointer resulting in a runtime crash.
		[DllImport("astyle", CallingConvention = CallingConvention.StdCall)]
		private static extern IntPtr AStyleGetVersion();

		// Cannot use string as a return value because Mono runtime will attempt to
		// free the returned pointer resulting in a runtime crash.
		[DllImport("astyle", CallingConvention = CallingConvention.StdCall)]
		private static extern IntPtr AStyleMain([MarshalAs(UnmanagedType.LPStr)] string sIn,
		                                        [MarshalAs(UnmanagedType.LPStr)] string sOptions,
		                                        AStyleErrorDelgate errorFunc,
		                                        AStyleMemAllocDelgate memAllocFunc);

		// AStyleMain callbacks
		private delegate IntPtr AStyleMemAllocDelgate(int size);

		private delegate void AStyleErrorDelgate(
			int errorNum, [MarshalAs(UnmanagedType.LPStr)] string error);

		// AStyleMain Delegates
		private readonly AStyleMemAllocDelgate AStyleMemAlloc;
		private readonly AStyleErrorDelgate AStyleError;

		private readonly ILog log;

		/// Declare callback functions
		public AStyleInterface(ILog log = null)
		{
			AStyleMemAlloc = new AStyleMemAllocDelgate(OnAStyleMemAlloc);
			AStyleError = new AStyleErrorDelgate(OnAStyleError);

			this.log = log ?? new ConsoleLog();
		}

		/// Call the AStyleMain function in Artistic Style.
		/// null is returned on error.
		public string FormatSource(string textIn, string options)
		{
			// Return the allocated string
			// Memory space is allocated by OnAStyleMemAlloc, a callback function from AStyle
			string sTextOut = null;
			try
			{
				IntPtr pText = AStyleMain(textIn, options, AStyleError, AStyleMemAlloc);
				if (pText != IntPtr.Zero)
				{
					sTextOut = Marshal.PtrToStringAnsi(pText);
					Marshal.FreeHGlobal(pText);
				}
			}
			catch (DllNotFoundException e)
			{
				log.Error(-1, e.ToString());
			}
			catch (EntryPointNotFoundException e)
			{
				log.Error(-1, e.ToString());
			}
			return sTextOut;
		}

		/// Get the Artistic Style version number.
		/// Does not need to terminate on error.
		/// But the exception must be handled when a function is called.
		public string GetVersion()
		{
			string sVersion = null;
			try
			{
				IntPtr pVersion = AStyleGetVersion();
				if (pVersion != IntPtr.Zero)
				{
					sVersion = Marshal.PtrToStringAnsi(pVersion);
				}
			}
			catch (DllNotFoundException e)
			{
				log.Error(-1, e.ToString());
			}
			catch (EntryPointNotFoundException e)
			{
				log.Error(-1, e.ToString());
			}
			return sVersion;
		}

		// Allocate the memory for the Artistic Style return string.
		private IntPtr OnAStyleMemAlloc(int size)
		{
			return Marshal.AllocHGlobal(size);
		}

		// Display errors from Artistic Style
		private void OnAStyleError(int errorNumber, string errorMessage)
		{
			if (errorNumber >= 200 && errorNumber < 300)
				log.Warning(errorNumber, errorMessage);
			else
				log.Error(errorNumber, errorMessage);
		}

		public interface ILog
		{
			void Error(int errorNumber, string errorMessage);
			void Warning(int errorNumber, string errorMessage);
		}

		private class ConsoleLog : ILog
		{
			public void Error(int errorNumber, string errorMessage)
			{
				Console.WriteLine("[AStyle] [ERROR] " + errorNumber + " - " + errorMessage);
			}

			public void Warning(int errorNumber, string errorMessage)
			{
				Console.WriteLine("[AStyle] [WARN ] " + errorNumber + " - " + errorMessage);
			}
		}
	}
}
