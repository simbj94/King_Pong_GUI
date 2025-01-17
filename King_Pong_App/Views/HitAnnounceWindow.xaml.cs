﻿using System;
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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace King_Pong_App.Views
{
	/// <summary>
	/// Interaction logic for HitAnnounceWindow.xaml
	/// </summary>
	public partial class HitAnnounceWindow : Window
	{
		/// <summary>
		/// Prints relevant info and starts a timer for closing the window
		/// </summary>
		public HitAnnounceWindow()
		{
			InitializeComponent();
			HitPrint();
			StartCloseTimer(2);
		}
		/// <summary>
		/// Shows the name of the current player that hit a cup
		/// </summary>
		public void HitPrint()
		{
			if (MainWindow.game.StarterTeamDecided)
			{
				AnnounceHitLabel.Content = $"{MainWindow.game.Current.Roster[MainWindow.game.currentPlayer].PlayerName.ToUpper()} \nRAMTE!";
				return;
			}

			AnnounceHitLabel.Content = $"DER ER RAMT!! \n{MainWindow.game.Current.TeamName.ToUpper()} \nSTARTER!";
		}
		/// <summary>
		/// Closes the window after a delay determined by the 'second' argument
		/// </summary>
		/// <param name="seconds"></param>
		private void StartCloseTimer(double seconds)
		{
			DispatcherTimer timer = new DispatcherTimer();
			timer.Interval = TimeSpan.FromSeconds(seconds);
			timer.Tick += TimerTick;
			timer.Start();
		}

		private void TimerTick(object sender, EventArgs e)
		{
			DispatcherTimer timer = (DispatcherTimer)sender;
			timer.Stop();
			timer.Tick -= TimerTick;
			Close();
		}

		private void Luk_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}
	}
}
