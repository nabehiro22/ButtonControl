using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System.ComponentModel;
using System.Reactive.Disposables;

namespace ButtonControl.ViewModels
{
    public class MainWindowViewModel : BindableBase, INotifyPropertyChanged
	{
		public ReactivePropertySlim<string> Title { get; } = new ReactivePropertySlim<string>("Button Control Application");

		private CompositeDisposable Disposable { get; } = new CompositeDisposable();

		public ReactiveCommand ButtonDownCommand { get; } = new ReactiveCommand();

		public ReactiveCommand ButtonUpCommand { get; } = new ReactiveCommand();

		public ReactivePropertySlim<string> ButtonContent { get; } = new ReactivePropertySlim<string>("押されてない");

		public MainWindowViewModel()
        {
			ButtonDownCommand.Subscribe(ButtonDownEvents).AddTo(Disposable);
			ButtonUpCommand.Subscribe(ButtonUpEvents).AddTo(Disposable);
		}

		/// <summary>
		/// ボタンを押したタイミング
		/// </summary>
		private void ButtonDownEvents()
		{
			ButtonContent.Value = "押した";
		}

		/// <summary>
		/// ボタンを放したタイミング
		/// </summary>
		private void ButtonUpEvents()
		{
			ButtonContent.Value = "離した";
		}
    }
}
