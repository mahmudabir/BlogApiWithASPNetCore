USE [BlogApiWithASPNetCore]
GO
ALTER TABLE [dbo].[Posts] DROP CONSTRAINT [FK_Posts_Users_UserId]
GO
ALTER TABLE [dbo].[Comments] DROP CONSTRAINT [FK_Comments_Users_UserId]
GO
ALTER TABLE [dbo].[Comments] DROP CONSTRAINT [FK_Comments_Posts_PostId]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 4/24/2021 4:39:02 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
DROP TABLE [dbo].[Users]
GO
/****** Object:  Table [dbo].[Posts]    Script Date: 4/24/2021 4:39:02 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Posts]') AND type in (N'U'))
DROP TABLE [dbo].[Posts]
GO
/****** Object:  Table [dbo].[Comments]    Script Date: 4/24/2021 4:39:02 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Comments]') AND type in (N'U'))
DROP TABLE [dbo].[Comments]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 4/24/2021 4:39:02 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[__EFMigrationsHistory]') AND type in (N'U'))
DROP TABLE [dbo].[__EFMigrationsHistory]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 4/24/2021 4:39:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comments]    Script Date: 4/24/2021 4:39:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Content] [nvarchar](max) NULL,
	[CommentTime] [datetime2](7) NOT NULL,
	[UserId] [int] NOT NULL,
	[PostId] [int] NOT NULL,
 CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Posts]    Script Date: 4/24/2021 4:39:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Posts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Content] [nvarchar](max) NULL,
	[PostTime] [datetime2](7) NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_Posts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 4/24/2021 4:39:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Comments] ON 

INSERT [dbo].[Comments] ([Id], [Content], [CommentTime], [UserId], [PostId]) VALUES (1, N'Test Comment', CAST(N'2020-12-22T16:59:02.1900000' AS DateTime2), 1, 10)
INSERT [dbo].[Comments] ([Id], [Content], [CommentTime], [UserId], [PostId]) VALUES (2, N'Test Comment Abir', CAST(N'2020-12-22T16:59:26.1766667' AS DateTime2), 1, 9)
INSERT [dbo].[Comments] ([Id], [Content], [CommentTime], [UserId], [PostId]) VALUES (3, N'Test Comment Abir', CAST(N'2020-12-22T16:59:31.5033333' AS DateTime2), 1, 8)
INSERT [dbo].[Comments] ([Id], [Content], [CommentTime], [UserId], [PostId]) VALUES (4, N'Test Comment Abir', CAST(N'2020-12-22T16:59:40.9433333' AS DateTime2), 1, 7)
INSERT [dbo].[Comments] ([Id], [Content], [CommentTime], [UserId], [PostId]) VALUES (5, N'Test Comment Abir', CAST(N'2020-12-22T16:59:47.9600000' AS DateTime2), 1, 6)
INSERT [dbo].[Comments] ([Id], [Content], [CommentTime], [UserId], [PostId]) VALUES (6, N'Test Comment Abir', CAST(N'2020-12-22T16:59:53.3666667' AS DateTime2), 1, 5)
INSERT [dbo].[Comments] ([Id], [Content], [CommentTime], [UserId], [PostId]) VALUES (7, N'Test Comment Abir', CAST(N'2020-12-22T17:00:04.6266667' AS DateTime2), 1, 4)
INSERT [dbo].[Comments] ([Id], [Content], [CommentTime], [UserId], [PostId]) VALUES (8, N'Test Comment Abir', CAST(N'2020-12-22T17:00:15.6733333' AS DateTime2), 1, 3)
INSERT [dbo].[Comments] ([Id], [Content], [CommentTime], [UserId], [PostId]) VALUES (9, N'Test Comment Abir', CAST(N'2020-12-22T17:00:23.8733333' AS DateTime2), 1, 2)
INSERT [dbo].[Comments] ([Id], [Content], [CommentTime], [UserId], [PostId]) VALUES (10, N'Test Comment Abir', CAST(N'2020-12-22T17:00:29.6900000' AS DateTime2), 1, 1)
INSERT [dbo].[Comments] ([Id], [Content], [CommentTime], [UserId], [PostId]) VALUES (11, N'Test Comment Imran', CAST(N'2020-12-22T17:00:59.8900000' AS DateTime2), 5, 10)
INSERT [dbo].[Comments] ([Id], [Content], [CommentTime], [UserId], [PostId]) VALUES (12, N'Test Comment Imran', CAST(N'2020-12-22T17:01:05.6733333' AS DateTime2), 5, 9)
INSERT [dbo].[Comments] ([Id], [Content], [CommentTime], [UserId], [PostId]) VALUES (13, N'Test Comment Imran', CAST(N'2020-12-22T17:01:11.4633333' AS DateTime2), 5, 8)
INSERT [dbo].[Comments] ([Id], [Content], [CommentTime], [UserId], [PostId]) VALUES (14, N'Test Comment Imran', CAST(N'2020-12-22T17:01:16.6066667' AS DateTime2), 5, 7)
INSERT [dbo].[Comments] ([Id], [Content], [CommentTime], [UserId], [PostId]) VALUES (15, N'Test Comment Imran', CAST(N'2020-12-22T17:01:30.4000000' AS DateTime2), 5, 5)
INSERT [dbo].[Comments] ([Id], [Content], [CommentTime], [UserId], [PostId]) VALUES (16, N'Test Comment Imran', CAST(N'2020-12-22T17:01:42.6000000' AS DateTime2), 5, 6)
INSERT [dbo].[Comments] ([Id], [Content], [CommentTime], [UserId], [PostId]) VALUES (17, N'Test Comment Imran', CAST(N'2020-12-22T17:01:53.2633333' AS DateTime2), 5, 3)
INSERT [dbo].[Comments] ([Id], [Content], [CommentTime], [UserId], [PostId]) VALUES (18, N'Test Comment Imran', CAST(N'2020-12-22T17:02:00.7533333' AS DateTime2), 5, 4)
INSERT [dbo].[Comments] ([Id], [Content], [CommentTime], [UserId], [PostId]) VALUES (19, N'Test Comment Imran', CAST(N'2020-12-22T17:02:13.8166667' AS DateTime2), 5, 2)
INSERT [dbo].[Comments] ([Id], [Content], [CommentTime], [UserId], [PostId]) VALUES (20, N'Test Comment Imran', CAST(N'2020-12-22T17:02:21.9533333' AS DateTime2), 5, 1)
SET IDENTITY_INSERT [dbo].[Comments] OFF
GO
SET IDENTITY_INSERT [dbo].[Posts] ON 

INSERT [dbo].[Posts] ([Id], [Title], [Content], [PostTime], [UserId]) VALUES (1, N'FakerPress', N'With over 900 downloads and a consistent five start rating. FakerPress is currently the leading and a very popular test data generation plugin which provides a clean way to generate fake and dummy content to your WordPress which is perfect for developers who need testing.

FakerPress gives the option to set the number of posts to generate, it also allows the creation of various post types such as a regular post, pages, users, categories, attachments etc. Additionally, the plugin allows you to select the image service to use for creating the featured images. It’s able to interact with major image hosting services such as 500px and Unsplash.', CAST(N'2020-12-22T16:54:05.9366667' AS DateTime2), 1)
INSERT [dbo].[Posts] ([Id], [Title], [Content], [PostTime], [UserId]) VALUES (2, N'WP Dummy Content', N'The next of the list is WP Dummy Content. Whilst not as often updated as FakerPress, it is still a very good WordPress Plugin to generate dummy content on your blog. It automatically creates posts, pages etc with single or multiple paragraphs of text. You can also insert unordered lists, shortcodes, block-quotes, links etc with just a click.', CAST(N'2020-12-22T16:54:30.9066667' AS DateTime2), 1)
INSERT [dbo].[Posts] ([Id], [Title], [Content], [PostTime], [UserId]) VALUES (3, N'Lorem Ipsum Post Generator', N'Lorem Ipsum Post Generator is a simple plugin that generates posts and comments automatically. It’s also super easy to use, All you need to do is to just specify the number of posts and number of comments per post, rest of the job will be done by this plugin. One thing missing in this plugin is that it doesn’t have the ability to generate pages, categories, tags etc.', CAST(N'2020-12-22T16:54:52.1233333' AS DateTime2), 2)
INSERT [dbo].[Posts] ([Id], [Title], [Content], [PostTime], [UserId]) VALUES (4, N'WP Lorem Ipsum Generator', N'Just as the name suggests, this plugin helps to add lorem ipsum text to any post on your blog. A button will be displayed in the toolbar of post editor (WYSIWYG editor), which helps to insert dummy text inside the post. Apart from generating dummy text, it doesn’t have any further options. It simplicity makes it useful when you need to go a little testing without generating a lot of random posts.', CAST(N'2020-12-22T16:55:33.7100000' AS DateTime2), 2)
INSERT [dbo].[Posts] ([Id], [Title], [Content], [PostTime], [UserId]) VALUES (5, N'Better Lorem Ipsum Generator', N'The next of the list is WP Dummy Content. Whilst not as often updated as FakerPress, it is still a very good WordPress Plugin to generate dummy content on your blog. It automatically creates posts, pages etc with single or multiple paragraphs of text. You can also insert unordered lists, shortcodes, block-quotes, links etc with just a click.', CAST(N'2020-12-22T16:56:25.1466667' AS DateTime2), 3)
INSERT [dbo].[Posts] ([Id], [Title], [Content], [PostTime], [UserId]) VALUES (6, N'WP Lipsum', N'WP Lipsum is yet another dummy data generator WordPress plugin, it allows you to add dummy text using Shortcodes and Template tags. This is a great plugin for generating dummy text on your WordPress Blog with ease. We recommend trying this awesome plugin when you need to do some light testing', CAST(N'2020-12-22T16:56:44.5700000' AS DateTime2), 3)
INSERT [dbo].[Posts] ([Id], [Title], [Content], [PostTime], [UserId]) VALUES (7, N'WP Dummy Post Generator', N'WP Dummy Post Generator is also a very simple dummy content generator plugin for WordPress. The plugin allows you to add dummy posts and dummy categories to your WordPress blog. The plugin also lets you specify a Blog Name and Title to be set.

You can export the settings of the plugin on another blog as well. The plugin will generate a predefined set of subcategories and categories and creates random posts in them.', CAST(N'2020-12-22T16:57:13.5133333' AS DateTime2), 4)
INSERT [dbo].[Posts] ([Id], [Title], [Content], [PostTime], [UserId]) VALUES (8, N'Demo Data Creator', N'Demo Data Creator is another popular test data plugin generator for WordPress. The plugin allows a WordPress developer to create demo users, blogs, posts, comments and blogroll link. If you’re testing out your site with BuddyPress or Multisite enabled then Demo Data Creator is the right plugin for you.

The plugin allows you to add dummy content for both of these setups. Adds and lets you control the number of users, categories, tags , posts, comments, pages etc. Deletes all the dummy data from your website. On BuddyPress, it adds and lets you control the number of Groups, wire messages, friends, member status.', CAST(N'2020-12-22T16:57:27.0566667' AS DateTime2), 4)
INSERT [dbo].[Posts] ([Id], [Title], [Content], [PostTime], [UserId]) VALUES (9, N'Lorem Ipsum Generator Shortcode', N'Lorem Ipsum Generator Shortcode is another best dummy content generator plugin available for WordPress. The plugin enables you to generate dummy content in posts and pages on your WordPress website. It is a very simple plugin and does not provide many options.

In other words, you can add dummy text in your post or page using shortcodes. The plugin is easy to set up and doesn’t require many configurations.', CAST(N'2020-12-22T16:57:50.6666667' AS DateTime2), 5)
INSERT [dbo].[Posts] ([Id], [Title], [Content], [PostTime], [UserId]) VALUES (10, N'WP Example Content', N'WP Example Content is one of the simplest plugins that helps you to generate dummy content on your WordPress website. The plugin adds dummy text that helps you in developing a new themes or website. You can delete the whole content with the help of this plugin.

One of the disadvantages of the plugin is that it only adds dummy posts. It doesn’t category, tags, comments etc. to your website. Add six types of posts like multiple paragraph post, image post, post with links, Blockquote post, UL and OL post and post with header text from H1 to H5.

Allows you to remove all the dummy content in just a single click. Format posts with different styles.', CAST(N'2020-12-22T16:58:15.1466667' AS DateTime2), 5)
SET IDENTITY_INSERT [dbo].[Posts] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Username], [Password]) VALUES (1, N'abir', N'abir')
INSERT [dbo].[Users] ([Id], [Username], [Password]) VALUES (2, N'leon', N'leon')
INSERT [dbo].[Users] ([Id], [Username], [Password]) VALUES (3, N'hasib', N'hasib')
INSERT [dbo].[Users] ([Id], [Username], [Password]) VALUES (4, N'tanvir', N'tanvir')
INSERT [dbo].[Users] ([Id], [Username], [Password]) VALUES (5, N'imran', N'imran')
INSERT [dbo].[Users] ([Id], [Username], [Password]) VALUES (6, N'milon', N'milon')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Posts_PostId] FOREIGN KEY([PostId])
REFERENCES [dbo].[Posts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Posts_PostId]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Users_UserId]
GO
ALTER TABLE [dbo].[Posts]  WITH CHECK ADD  CONSTRAINT [FK_Posts_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Posts] CHECK CONSTRAINT [FK_Posts_Users_UserId]
GO
