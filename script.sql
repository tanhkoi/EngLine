USE DBDACS;
DBCC CHECKIDENT ('Tests', RESEED, 0);
DBCC CHECKIDENT ('Questions', RESEED, 0);
DBCC CHECKIDENT ('AnswerOptions', RESEED, 0);
DBCC CHECKIDENT ('Courses', RESEED, 0);
SET IDENTITY_INSERT Orders ON
-- Insert into tests table
INSERT INTO Tests (Title, TimeLimit, TeacherId)
VALUES ('Sample Test 1', 5, '02b83a50-870f-49c1-bc5d-4ba4bfcac68f'),
    ('Sample Test 2', 5, '02b83a50-870f-49c1-bc5d-4ba4bfcac68f');
-- Insert into questions table	
INSERT INTO Questions (Content, TestId, Point)
VALUES ('What is the capital of France?', 1, 10),
    ('What is 2 + 2?', 1, 10),
    ('Who wrote "Hamlet"?', 2, 10),
    ('What is the boiling point of water?', 2, 10);
-- Insert into answer_options table
INSERT INTO AnswerOptions(Content, QuestionId, IsCorrectOption)
VALUES ('Paris', 1, 1),
    ('London', 1, 0),
    ('Berlin', 1, 0),
    ('Madrid', 1, 0),
    ('3', 2, 0),
    ('4', 2, 1),
    ('5', 2, 0),
    ('6', 2, 0),
    ('William Shakespeare', 3, 1),
    ('Charles Dickens', 3, 0),
    ('Mark Twain', 3, 0),
    ('Jane Austen', 3, 0),
    ('90°C', 4, 0),
    ('100°C', 4, 1),
    ('110°C', 4, 0),
    ('120°C', 4, 0);
-- Insert into method payments
INSERT INTO PaymentMethods(Name)
VALUES('MOMO'),
    ('VNPAY'),
    ('CREDIT CARD')

-- Insert into certificates table
INSERT INTO Certificates(Name, ScoreMin, ScoreMax)
VALUES 
('IELTS', 0, 9),
('TOEIC', 10, 990),
('TOEFL', 0, 120),
('Cambridge English', 80, 230),
('PTE Academic', 10, 90);


-- SeedCourses.sql

-- Insert data into Courses table
INSERT INTO Courses (TeacherId, TestId, CourseName, CoverPhoto, Price, Description, MinScore, IsDelete)
VALUES
    ('04ac9a2e-6360-42f1-9db3-e1f4f3b2cb1a', 1, 'Elementary English', 'https://res.cloudinary.com/dqnmqwbqy/image/upload/v1718639959/expamle6_gos9ap.jpg', 299000, 'An intermediate level English course', 7, 0),
    -- Add more courses as needed
    ('04ac9a2e-6360-42f1-9db3-e1f4f3b2cb1a', 2, 'Intermediate English', 'https://res.cloudinary.com/dqnmqwbqy/image/upload/v1718639959/expamle7_q62fpd.jpg', 399000, 'An advanced level Math course', 7, 0),
    ('04ac9a2e-6360-42f1-9db3-e1f4f3b2cb1a', 3, 'Advanced English', 'https://res.cloudinary.com/dqnmqwbqy/image/upload/v1718639960/expamle5_ztbxhr.jpg', 490000, 'A comprehensive course on the History of Art', 7, 0),
	
    ('4ea7c18d-dd24-448e-8a00-6d0f6477c65c', 1, 'Business English', 'https://res.cloudinary.com/dqnmqwbqy/image/upload/v1718639959/expamle1_rewhjl.jpg', 399000, 'A course focused on English for business purposes', 7, 0),
    ('4ea7c18d-dd24-448e-8a00-6d0f6477c65c', 2, 'IELTS Preparation', 'https://res.cloudinary.com/dqnmqwbqy/image/upload/v1718639959/expamle4_oxr76h.jpg', 490000, 'Preparation course for the IELTS exam', 7, 0),
	('4ea7c18d-dd24-448e-8a00-6d0f6477c65c', 3, 'TOEFL Preparation', 'https://res.cloudinary.com/dqnmqwbqy/image/upload/v1718639960/expamle2_ktfynl.jpg', 399000, 'Preparation course for the TOEFL exam', 7, 0),
    
    ('945e3f3d-e139-48f9-bf21-5c1a4703111f', 1, 'English for Travel', 'https://res.cloudinary.com/dqnmqwbqy/image/upload/v1718639959/expamle3_looh5i.jpg', 490000, 'A practical course for English used during travel', 7, 0)


-- Insert lessons for Course 1
INSERT INTO Lessons (CourseId, Name, Description, Photo, Video, [Content])
VALUES
(7, 'Lesson 7.1', 'Description of Lesson 7.1', 'https://res.cloudinary.com/dqnmqwbqy/image/upload/v1718639959/expamle6_gos9ap.jpg', 'https://res.cloudinary.com/dqnmqwbqy/video/upload/v1718641544/English_Listening_Story_To_Practice_Speaking_Daily_Conversation_in_English_pk5ztm.mp4', 'Content of Lesson 7.1'),
(7, 'Lesson 7.2', 'Description of Lesson 7.2', 'https://res.cloudinary.com/dqnmqwbqy/image/upload/v1718639959/expamle6_gos9ap.jpg', 'https://res.cloudinary.com/dqnmqwbqy/video/upload/v1718641562/Listening_Conversations_English_Speaking_Practice___Listen_And_Speak_npdwbj.mp4', 'Content of Lesson 7.2'),
(7, 'Lesson 7.3', 'Description of Lesson 7.3', 'https://res.cloudinary.com/dqnmqwbqy/image/upload/v1718639959/expamle6_gos9ap.jpg', 'https://res.cloudinary.com/dqnmqwbqy/video/upload/v1718641571/Listen_and_Speak_English_Story_For_Simple_Present_Tense_oai1lk.mp4', 'Content of Lesson 7.3'),
(7, 'Lesson 7.4', 'Description of Lesson 7.4', 'https://res.cloudinary.com/dqnmqwbqy/image/upload/v1718639959/expamle6_gos9ap.jpg', 'https://res.cloudinary.com/dqnmqwbqy/video/upload/v1718643601/Short_Stories_for_Learning_English___Past_Continuous_Story_Listen_Speak_blouob.mp4', 'Content of Lesson 7.4'),
(7, 'Lesson 7.5', 'Description of Lesson 7.5', 'https://res.cloudinary.com/dqnmqwbqy/image/upload/v1718639959/expamle6_gos9ap.jpg', 'https://res.cloudinary.com/dqnmqwbqy/video/upload/v1718643623/Speak_English_Like_a_Native___Present_Perfect_Story_Practice_cbsp0i.mp4', 'Content of Lesson 7.5'),
(7, 'Lesson 7.6', 'Description of Lesson 7.6', 'https://res.cloudinary.com/dqnmqwbqy/image/upload/v1718639959/expamle6_gos9ap.jpg', 'https://res.cloudinary.com/dqnmqwbqy/video/upload/v1718643649/Learning_English_Fairy_Tales___Stories_For_Listening_And_Speaking_Practice_dnqppm.mp4', 'Content of Lesson 7.6'),
(7, 'Lesson 7.7', 'Description of Lesson 7.7', 'https://res.cloudinary.com/dqnmqwbqy/image/upload/v1718639959/expamle6_gos9ap.jpg', 'https://res.cloudinary.com/dqnmqwbqy/video/upload/v1718643663/Learn_English_Through_Stories_The_Neighborhood_Picnic___Listen_and_Speak_English_zeip5q.mp4', 'Content of Lesson 7.7'),
(7, 'Lesson 7.8', 'Description of Lesson 7.8', 'https://res.cloudinary.com/dqnmqwbqy/image/upload/v1718639959/expamle6_gos9ap.jpg', 'https://res.cloudinary.com/dqnmqwbqy/video/upload/v1718643601/Short_Stories_for_Learning_English___Past_Continuous_Story_Listen_Speak_blouob.mp4', 'Content of Lesson 7.8');

-- Insert lessons for Course 2
INSERT INTO Lessons (CourseId, Name, Description, Photo, Video, [Content])
VALUES
(2, 'Lesson 7.1', 'Description of Lesson 7.1', 'https://res.cloudinary.com/dqnmqwbqy/image/upload/v1718639959/expamle6_gos9ap.jpg', 'https://res.cloudinary.com/dqnmqwbqy/video/upload/v1718641544/English_Listening_Story_To_Practice_Speaking_Daily_Conversation_in_English_pk5ztm.mp4', 'Content of Lesson 7.1'),
(2, 'Lesson 7.2', 'Description of Lesson 7.2', 'https://res.cloudinary.com/dqnmqwbqy/image/upload/v1718639959/expamle6_gos9ap.jpg', 'https://res.cloudinary.com/dqnmqwbqy/video/upload/v1718641562/Listening_Conversations_English_Speaking_Practice___Listen_And_Speak_npdwbj.mp4', 'Content of Lesson 7.2');

-- Insert lessons for Course 3
INSERT INTO Lessons (CourseId, Name, Description, Photo, Video, [Content])
VALUES
(3, 'Lesson 7.1', 'Description of Lesson 7.1', 'https://res.cloudinary.com/dqnmqwbqy/image/upload/v1718639959/expamle6_gos9ap.jpg', 'https://res.cloudinary.com/dqnmqwbqy/video/upload/v1718641544/English_Listening_Story_To_Practice_Speaking_Daily_Conversation_in_English_pk5ztm.mp4', 'Content of Lesson 7.1'),
(3, 'Lesson 7.2', 'Description of Lesson 7.2', 'https://res.cloudinary.com/dqnmqwbqy/image/upload/v1718639959/expamle6_gos9ap.jpg', 'https://res.cloudinary.com/dqnmqwbqy/video/upload/v1718641562/Listening_Conversations_English_Speaking_Practice___Listen_And_Speak_npdwbj.mp4', 'Content of Lesson 7.2'),
(3, 'Lesson 7.3', 'Description of Lesson 7.3', 'https://res.cloudinary.com/dqnmqwbqy/image/upload/v1718639959/expamle6_gos9ap.jpg', 'https://res.cloudinary.com/dqnmqwbqy/video/upload/v1718641571/Listen_and_Speak_English_Story_For_Simple_Present_Tense_oai1lk.mp4', 'Content of Lesson 7.3');

-- Insert lessons for Course 4
INSERT INTO Lessons (CourseId, Name, Description, Photo, Video, [Content])
VALUES
(4, 'Lesson 7.1', 'Description of Lesson 7.1', 'https://res.cloudinary.com/dqnmqwbqy/image/upload/v1718639959/expamle6_gos9ap.jpg', 'https://res.cloudinary.com/dqnmqwbqy/video/upload/v1718641544/English_Listening_Story_To_Practice_Speaking_Daily_Conversation_in_English_pk5ztm.mp4', 'Content of Lesson 7.1'),
(4, 'Lesson 7.2', 'Description of Lesson 7.2', 'https://res.cloudinary.com/dqnmqwbqy/image/upload/v1718639959/expamle6_gos9ap.jpg', 'https://res.cloudinary.com/dqnmqwbqy/video/upload/v1718641562/Listening_Conversations_English_Speaking_Practice___Listen_And_Speak_npdwbj.mp4', 'Content of Lesson 7.2');

-- Insert lessons for Course 5
INSERT INTO Lessons (CourseId, Name, Description, Photo, Video, [Content])
VALUES
(5, 'Lesson 7.1', 'Description of Lesson 7.1', 'https://res.cloudinary.com/dqnmqwbqy/image/upload/v1718639959/expamle6_gos9ap.jpg', 'https://res.cloudinary.com/dqnmqwbqy/video/upload/v1718641544/English_Listening_Story_To_Practice_Speaking_Daily_Conversation_in_English_pk5ztm.mp4', 'Content of Lesson 7.1'),
(5, 'Lesson 7.2', 'Description of Lesson 7.2', 'https://res.cloudinary.com/dqnmqwbqy/image/upload/v1718639959/expamle6_gos9ap.jpg', 'https://res.cloudinary.com/dqnmqwbqy/video/upload/v1718641562/Listening_Conversations_English_Speaking_Practice___Listen_And_Speak_npdwbj.mp4', 'Content of Lesson 7.2'),
(5, 'Lesson 7.3', 'Description of Lesson 7.3', 'https://res.cloudinary.com/dqnmqwbqy/image/upload/v1718639959/expamle6_gos9ap.jpg', 'https://res.cloudinary.com/dqnmqwbqy/video/upload/v1718641571/Listen_and_Speak_English_Story_For_Simple_Present_Tense_oai1lk.mp4', 'Content of Lesson 7.3');


