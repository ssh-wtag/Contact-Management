
DELETE FROM Contacts

DELETE FROM Groups

DELETE FROM ContactGroup

GO	

USE [DEMO]
GO
SET IDENTITY_INSERT [dbo].[Contacts] ON 
GO
INSERT [dbo].[Contacts] ([ContactId], [Name], [Number], [Email], [Address]) VALUES (1, N'Shanto', N'01812345463', N'shanto@gmail.com', N'Khulna')
GO
INSERT [dbo].[Contacts] ([ContactId], [Name], [Number], [Email], [Address]) VALUES (2, N'Shoumik', N'01712312312', N'shoumik@gmail.com', N'Savar')
GO
INSERT [dbo].[Contacts] ([ContactId], [Name], [Number], [Email], [Address]) VALUES (3, N'Riad', N'01234534345', N'riad@gmail.com', N'Savar')
GO
INSERT [dbo].[Contacts] ([ContactId], [Name], [Number], [Email], [Address]) VALUES (4, N'Siddik', N'01711232323', N'siddik@gmail.com', N'Jamalpur')
GO
INSERT [dbo].[Contacts] ([ContactId], [Name], [Number], [Email], [Address]) VALUES (5, N'Tajwar', N'01912312321', N'tajwar@gmail.com', N'Badda')
GO
INSERT [dbo].[Contacts] ([ContactId], [Name], [Number], [Email], [Address]) VALUES (6, N'Reaz', N'01612312312', N'reaz@gmail.com', N'Comilla')
GO
SET IDENTITY_INSERT [dbo].[Contacts] OFF
GO
SET IDENTITY_INSERT [dbo].[Groups] ON 
GO
INSERT [dbo].[Groups] ([GroupId], [GroupName]) VALUES (1, N'Family')
GO
INSERT [dbo].[Groups] ([GroupId], [GroupName]) VALUES (2, N'Friend')
GO
INSERT [dbo].[Groups] ([GroupId], [GroupName]) VALUES (3, N'Work')
GO
SET IDENTITY_INSERT [dbo].[Groups] OFF
GO
INSERT [dbo].[ContactGroup] ([ContactsContactId], [GroupsGroupId]) VALUES (2, 1)
GO
INSERT [dbo].[ContactGroup] ([ContactsContactId], [GroupsGroupId]) VALUES (1, 2)
GO
INSERT [dbo].[ContactGroup] ([ContactsContactId], [GroupsGroupId]) VALUES (2, 2)
GO
INSERT [dbo].[ContactGroup] ([ContactsContactId], [GroupsGroupId]) VALUES (3, 2)
GO
INSERT [dbo].[ContactGroup] ([ContactsContactId], [GroupsGroupId]) VALUES (4, 2)
GO
INSERT [dbo].[ContactGroup] ([ContactsContactId], [GroupsGroupId]) VALUES (1, 3)
GO
INSERT [dbo].[ContactGroup] ([ContactsContactId], [GroupsGroupId]) VALUES (2, 3)
GO
INSERT [dbo].[ContactGroup] ([ContactsContactId], [GroupsGroupId]) VALUES (5, 3)
GO
INSERT [dbo].[ContactGroup] ([ContactsContactId], [GroupsGroupId]) VALUES (6, 3)
GO
