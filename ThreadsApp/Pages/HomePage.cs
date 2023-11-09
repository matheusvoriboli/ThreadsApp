namespace ThreadsApp.Pages;
using CommunityToolkit.Maui.Markup;
using CommunityToolkit.Mvvm.ComponentModel;
using ThreadsApp.Helpers;
using static CommunityToolkit.Maui.Markup.GridRowsColumns;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		var listView = new ListView(ListViewCachingStrategy.RecycleElement)
		{
			HasUnevenRows = true,
			ItemTemplate = new DataTemplate(typeof(ThreadCell)),
			IsPullToRefreshEnabled = true,
			SelectionMode = ListViewSelectionMode.None,
			SeparatorVisibility = SeparatorVisibility.None,
			ItemsSource = new[] {
				new AThread {
					User = "matheusriboli",
					Image = "profilecircle.png",
					Message = "This is a Thread Message you should read",
					IsVerified = false,
					Likes = 10,
					Replies = 2,
					TimeAgo = "2h"
				},
				new AThread {
					User = "dotnet.developers",
					Image = "profilecircle.png",
					Message = "Hi, I am .NET Bot. I am here to help you with your .NET related questions. I Will respond to commands that start with a dot. To see what i can do type .help. I will only respond once per thread.",
					Likes = 10,
					IsVerified = true,
					Replies = 2,
					TimeAgo = "2h"
				},
				new AThread {
					User = "matheusriboli",
					Image = "profilecircle.png",
					Message = "This is a Thread Message you should read",
					IsVerified = false,
					Likes = 10,
					Replies = 2,
					TimeAgo = "2h"
				},
				new AThread {
					User = "dotnet.developers",
					Image = "profilecircle.png",
					Message = "Hi, I am .NET Bot. I am here to help you with your .NET related questions. I Will respond to commands that start with a dot. To see what i can do type .help. I will only respond once per thread.",
					Likes = 10,
					IsVerified = true,
					Replies = 2,
					TimeAgo = "2h"
				},
				new AThread {
					User = "matheusriboli",
					Image = "profilecircle.png",
					Message = "This is a Thread Message you should read",
					IsVerified = false,
					Likes = 10,
					Replies = 2,
					TimeAgo = "2h"
				},
				new AThread {
					User = "dotnet.developers",
					Image = "profilecircle.png",
					Message = "Hi, I am .NET Bot. I am here to help you with your .NET related questions. I Will respond to commands that start with a dot. To see what i can do type .help. I will only respond once per thread.",
					Likes = 10,
					IsVerified = true,
					Replies = 2,
					TimeAgo = "2h"
				},
			}
		};

		Content = listView;
	}

	public partial class AThread : ObservableObject
	{
		[ObservableProperty]
		string user;
		[ObservableProperty]
		string message;
		[ObservableProperty]
		string image;
		[ObservableProperty]
		[NotifyPropertyChangedFor(nameof(HasLikes))]
		int likes;
		[ObservableProperty]
		[NotifyPropertyChangedFor(nameof(HasReplies))]
		int replies;
		[ObservableProperty]
		bool isVerified;
		[ObservableProperty]
		string timeAgo;

		public bool HasReplies => Replies > 0;
		public bool HasLikes => Likes > 0;
	}

	public class HorizontalStackLayoutSpaced : HorizontalStackLayout
	{
		public HorizontalStackLayoutSpaced(int spacing = 10)
		{
			Spacing = spacing;
		}
	}

	public class ThreadCell : ViewCell
	{
		public ThreadCell()
		{
			const int iconSize = 16;
			View = new Grid
			{
				Padding = 10,
				ColumnDefinitions = Columns.Define(Auto, Star, Auto, Auto),
				ColumnSpacing = 10,
				RowSpacing = 5,
				RowDefinitions = Rows.Define(Auto, Auto, Auto, Auto),
				Children =
				{
						new Image()
							.Bind(Image.SourceProperty, nameof(AThread.Image))
							.Width(35).Height(35)
							.Row(0).Column(0)
							.RowSpan(2)
							.CenterHorizontal()
							.Top()
							.Margin(new Thickness(0,5,0,0))
							.Aspect(Aspect.AspectFill),
					new HorizontalStackLayoutSpaced(5)
					{
						new Label()
							.Bind(Label.TextProperty, nameof(AThread.User))
							.Bold()
							.Bottom(),
						new Label()
							.Text(FontAwesomeIcons.CircleCheck)
							.Font("FAS")
							.TextColor(Colors.Blue)
							.Bind(Label.IsVisibleProperty, nameof(AThread.IsVerified))
							.Bottom()
					}.Row(0).Column(1),
					new Label()
							.Bind(Label.TextProperty, nameof(AThread.TimeAgo))
							.Row(0).Column(2)
							.Bottom(),
					new Label()
							.Text(FontAwesomeIcons.Ellipsis)
							.Font("FAS")
							.Row(0).Column(3)
							.Bottom(),
					new Label()
						.Bind(Label.TextProperty, nameof(AThread.Message))
						.Row(1).Column(1)
						.ColumnSpan(3),
					new HorizontalStackLayoutSpaced(){
						new Label()
						.Text(FontAwesomeIcons.Heart)
						.Font("FAR")
						.FontSize(iconSize),
						new Label()
						.Text(FontAwesomeIcons.Comment)
						.Font("FAR")
						.FontSize(iconSize),
						new Label()
						.Text(FontAwesomeIcons.Retweet)
						.Font("FAS")
						.FontSize(iconSize),
						new Label()
						.Text(FontAwesomeIcons.PaperPlane)
						.Font("FAR")
						.FontSize(iconSize)
					}.Row(2).Column(1),
					new HorizontalStackLayoutSpaced {
						new Label()
							.Bind(Label.TextProperty, nameof(AThread.Replies), stringFormat: "{0} replies")
							.Bind(Label.IsVisibleProperty, nameof(AThread.HasReplies))
							.CenterVertical(),
						new Label()
							.Bind(Label.TextProperty, nameof(AThread.Likes), stringFormat: "{0} likes")
							.Bind(Label.IsVisibleProperty, nameof(AThread.HasLikes))
							.CenterVertical(),
					}.Row(3).Column(1).ColumnSpan(3)
				}
			};
		}

	}
}