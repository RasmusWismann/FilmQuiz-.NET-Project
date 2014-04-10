CREATE TABLE Categories
(
C_Id int IDENTITY(1,1) PRIMARY KEY,
Name varchar(255) NOT NULL
)

CREATE TABLE Answers
(
A_Id int IDENTITY(1,1) PRIMARY KEY,
Answer varchar(255) NOT NULL
)

CREATE TABLE Questions
(
Q_Id int IDENTITY(1,1) PRIMARY KEY,
Question varchar(255) NOT NULL,
Category int FOREIGN KEY REFERENCES Categories(C_Id),
Answer int FOREIGN KEY REFERENCES Answers(A_Id)
)

CREATE TABLE FakeAnswersToQuestions(
Question int FOREIGN KEY REFERENCES Questions(Q_Id),
Answer int FOREIGN KEY REFERENCES Answers(A_Id),
PRIMARY KEY (Question, Answer)
)

CREATE TABLE Players
(
P_Id int IDENTITY(1,1) PRIMARY KEY,
Name varchar(255),
Points int not null,
Number int not null,
Game int FOREIGN KEY REFERENCES Games(G_Id)
)

CREATE TABLE Games 
(
	G_Id int IDENTITY(1,1) PRIMARY KEY,
	Name varchar(255),
	Turns int NOT NULL,
	PlayerTurn int NOT NULL,
	TurnNumber int NOT NULL,
	Category int FOREIGN KEY REFERENCES Categories(C_Id),
)


CREATE TABLE GameQuestions 
(
	Game int FOREIGN KEY REFERENCES Games(G_Id),
	Question int FOREIGN KEY REFERENCES Questions(Q_Id),
	PRIMARY KEY(Game, Question)
)