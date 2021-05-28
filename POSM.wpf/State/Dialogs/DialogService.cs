﻿using System;
using System.Collections.Generic;
using System.Windows;

namespace POSM.wpf.State.Dialogs
{
	public class DialogService : IDialogService
	{
		private readonly Window _owner;
		public IDictionary<Type, Type> Mappings { get; }

		public DialogService(Window owner)
		{
			_owner = owner;
			Mappings = new Dictionary<Type, Type>();
		}

		public void Register<TViewModel, TView>() where TViewModel : IDialogRequestClose
												  where TView : IDialog
		{
			if(Mappings.ContainsKey(typeof(TViewModel)))
			{
				throw new ArgumentException($"Type {typeof(TViewModel)} is already mapped to type {typeof(TView)}");
			}

			Mappings.Add(typeof(TViewModel), typeof(TView));
		}

		public bool? ShowDialog<TViewModel>(TViewModel viewmodel) where TViewModel : IDialogRequestClose
		{
			Type viewType = Mappings[typeof(TViewModel)];
			IDialog dialog = (IDialog)Activator.CreateInstance(viewType);
			EventHandler<DialogCloseRequestedEventArgs> handler = null;

			handler = (sender, e) =>
			{
				viewmodel.CloseRequested -= handler;

				if (e.DialogResult.HasValue)
				{
					dialog.DialogResult = e.DialogResult;
				}
				else
				{
					dialog.Close();
				}
			};

			viewmodel.CloseRequested += handler;
			
			dialog.DataContext = viewmodel;
			dialog.Owner = _owner;

			return dialog.ShowDialog();
		}
	}
}
