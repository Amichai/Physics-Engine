﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using PhysicsEngine;
using PhysicsEngine.Compiler;

namespace UserInterface {
	public enum LogType { input, output, token, parseTree, all, allTokens, postFixedTokens }
	static class UI {
		static List<Tuple<object, LogType>> objectLog = new List<Tuple<object, LogType>>();

		//UI Display Settings:
		static bool displayEachToken	= false;
		static bool displayAllTokens	= true;
		static bool displayInput		= true;
		static bool displayOutput		= true;

		public static string AddToLog(this string obj, LogType type){
			objectLog.Add(new Tuple<object, LogType>(type.ToString().ToUpper() + ": " + obj.ToString(), type));
			return obj;
		}

		public static double AddToLog(this double obj, LogType type) {
			objectLog.Add(new Tuple<object, LogType>(type.ToString().ToUpper() + ": " + obj.ToString(), type));
			return obj;
		}

		public static Tokens AddToLog(this Tokens obj, LogType type) {
			objectLog.Add(new Tuple<object, LogType>(type.ToString().ToUpper() + ": " + obj.Visualize(), type));
			return obj;
		}

		public static PostfixedTokens AddToLog(this PostfixedTokens obj, LogType type) {
			objectLog.Add(new Tuple<object, LogType>(type.ToString().ToUpper() + ": " + obj.Visualize(), type));
			return obj;
		}

		public static TreeNode AddToLog(this TreeNode obj, LogType type) {
			objectLog.Add(new Tuple<object, LogType>(type.ToString().ToUpper() + ": " + obj.Visualize("", true), type));
			return obj;
		}


		public static void Display(string textToDisplay) {
			Debug.Print(textToDisplay);
		}

		public static void DisplayLog(LogType logType) {
			foreach(Tuple<object, LogType> obj in objectLog){
				StackTrace stackTrace = new StackTrace();
				if(obj.Item2 == logType 
					//Check that we've selected to display this part of the log (from within this class)
					&& (!(obj.Item2 == LogType.token) || displayEachToken)
					&& (!(obj.Item2 == LogType.input) || displayInput)
					&& (!(obj.Item2 == LogType.output) || displayOutput)
					&& (!(obj.Item2 == LogType.allTokens) || displayAllTokens)){
					Debug.WriteLine("Called from: " + stackTrace.GetFrame(1).GetMethod().ToString());
					Debug.Print(obj.Item1.ToString());
				}
			}
		}
	}
}
