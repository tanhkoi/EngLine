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

-- Insert courses
INSERT INTO Courses (TeacherId, Price, Description, CourseName, CoverPhoto, IsDelete)
VALUES
('3482a329-f6c0-4d62-8771-c2a2e6ce6a83', 299000, 'Description of Course 1', 'Course 1', 'https://img.freepik.com/free-photo/young-asian-woman-lying-floor-home-with-laptop-with-small-pet-dog-beside_1098-20173.jpg?w=996&t=st=1717081476~exp=1717082076~hmac=43059ab343b9c0c945fea435e354d65b9d1dd07b5add7069be835b60602cd29c', 0),
('3482a329-f6c0-4d62-8771-c2a2e6ce6a83', 279000, 'Description of Course 2', 'Course 2', 'https://img.freepik.com/free-photo/young-asian-woman-lying-floor-home-with-laptop-with-small-pet-dog-beside_1098-20173.jpg?w=996&t=st=1717081476~exp=1717082076~hmac=43059ab343b9c0c945fea435e354d65b9d1dd07b5add7069be835b60602cd29c', 0),
('3482a329-f6c0-4d62-8771-c2a2e6ce6a83', 259000, 'Description of Course 3', 'Course 3', 'https://img.freepik.com/free-photo/young-asian-woman-lying-floor-home-with-laptop-with-small-pet-dog-beside_1098-20173.jpg?w=996&t=st=1717081476~exp=1717082076~hmac=43059ab343b9c0c945fea435e354d65b9d1dd07b5add7069be835b60602cd29c', 0),
('3482a329-f6c0-4d62-8771-c2a2e6ce6a83', 249000, 'Description of Course 4', 'Course 4', 'https://img.freepik.com/free-photo/young-asian-woman-lying-floor-home-with-laptop-with-small-pet-dog-beside_1098-20173.jpg?w=996&t=st=1717081476~exp=1717082076~hmac=43059ab343b9c0c945fea435e354d65b9d1dd07b5add7069be835b60602cd29c', 0),
('3482a329-f6c0-4d62-8771-c2a2e6ce6a83', 239000, 'Description of Course 5', 'Course 5', 'https://img.freepik.com/free-photo/young-asian-woman-lying-floor-home-with-laptop-with-small-pet-dog-beside_1098-20173.jpg?w=996&t=st=1717081476~exp=1717082076~hmac=43059ab343b9c0c945fea435e354d65b9d1dd07b5add7069be835b60602cd29c', 0);

-- Insert lessons for Course 1
INSERT INTO Lessons (CourseId, Name, Description, Photo, Video, [Content])
VALUES
(1, 'Lesson 1.1', 'Description of Lesson 1.1', 'https://img.freepik.com/free-photo/young-asian-woman-lying-floor-home-with-laptop-with-small-pet-dog-beside_1098-20173.jpg?w=996&t=st=1717081476~exp=1717082076~hmac=43059ab343b9c0c945fea435e354d65b9d1dd07b5add7069be835b60602cd29c', 'https://videos.pexels.com/video-files/20325563/20325563-hd_1280_720_60fps.mp4', 'Content of Lesson 1.1'),
(1, 'Lesson 1.2', 'Description of Lesson 1.2', 'https://img.freepik.com/free-photo/young-asian-woman-lying-floor-home-with-laptop-with-small-pet-dog-beside_1098-20173.jpg?w=996&t=st=1717081476~exp=1717082076~hmac=43059ab343b9c0c945fea435e354d65b9d1dd07b5add7069be835b60602cd29c', 'https://videos.pexels.com/video-files/20325563/20325563-hd_1280_720_60fps.mp4', 'Content of Lesson 1.2'),
(1, 'Lesson 1.3', 'Description of Lesson 1.3', 'https://img.freepik.com/free-photo/young-asian-woman-lying-floor-home-with-laptop-with-small-pet-dog-beside_1098-20173.jpg?w=996&t=st=1717081476~exp=1717082076~hmac=43059ab343b9c0c945fea435e354d65b9d1dd07b5add7069be835b60602cd29c', 'https://videos.pexels.com/video-files/20325563/20325563-hd_1280_720_60fps.mp4', 'Content of Lesson 1.3');

-- Insert lessons for Course 2
INSERT INTO Lessons (CourseId, Name, Description, Photo, Video, [Content])
VALUES
(2, 'Lesson 2.1', 'Description of Lesson 2.1', 'https://img.freepik.com/free-photo/young-asian-woman-lying-floor-home-with-laptop-with-small-pet-dog-beside_1098-20173.jpg?w=996&t=st=1717081476~exp=1717082076~hmac=43059ab343b9c0c945fea435e354d65b9d1dd07b5add7069be835b60602cd29c', 'https://videos.pexels.com/video-files/20325563/20325563-hd_1280_720_60fps.mp4', 'Content of Lesson 2.1'),
(2, 'Lesson 2.2', 'Description of Lesson 2.2', 'https://img.freepik.com/free-photo/young-asian-woman-lying-floor-home-with-laptop-with-small-pet-dog-beside_1098-20173.jpg?w=996&t=st=1717081476~exp=1717082076~hmac=43059ab343b9c0c945fea435e354d65b9d1dd07b5add7069be835b60602cd29c', 'https://videos.pexels.com/video-files/20325563/20325563-hd_1280_720_60fps.mp4', 'Content of Lesson 2.2');

-- Insert lessons for Course 3
INSERT INTO Lessons (CourseId, Name, Description, Photo, Video, [Content])
VALUES
(3, 'Lesson 3.1', 'Description of Lesson 3.1', 'https://img.freepik.com/free-photo/young-asian-woman-lying-floor-home-with-laptop-with-small-pet-dog-beside_1098-20173.jpg?w=996&t=st=1717081476~exp=1717082076~hmac=43059ab343b9c0c945fea435e354d65b9d1dd07b5add7069be835b60602cd29c', 'https://videos.pexels.com/video-files/20325563/20325563-hd_1280_720_60fps.mp4', 'Content of Lesson 3.1'),
(3, 'Lesson 3.2', 'Description of Lesson 3.2', 'https://img.freepik.com/free-photo/young-asian-woman-lying-floor-home-with-laptop-with-small-pet-dog-beside_1098-20173.jpg?w=996&t=st=1717081476~exp=1717082076~hmac=43059ab343b9c0c945fea435e354d65b9d1dd07b5add7069be835b60602cd29c', 'https://videos.pexels.com/video-files/20325563/20325563-hd_1280_720_60fps.mp4', 'Content of Lesson 3.2'),
(3, 'Lesson 3.3', 'Description of Lesson 3.3', 'https://img.freepik.com/free-photo/young-asian-woman-lying-floor-home-with-laptop-with-small-pet-dog-beside_1098-20173.jpg?w=996&t=st=1717081476~exp=1717082076~hmac=43059ab343b9c0c945fea435e354d65b9d1dd07b5add7069be835b60602cd29c', 'https://videos.pexels.com/video-files/20325563/20325563-hd_1280_720_60fps.mp4', 'Content of Lesson 3.3');

-- Insert lessons for Course 4
INSERT INTO Lessons (CourseId, Name, Description, Photo, Video, [Content])
VALUES
(4, 'Lesson 4.1', 'Description of Lesson 4.1', 'https://img.freepik.com/free-photo/young-asian-woman-lying-floor-home-with-laptop-with-small-pet-dog-beside_1098-20173.jpg?w=996&t=st=1717081476~exp=1717082076~hmac=43059ab343b9c0c945fea435e354d65b9d1dd07b5add7069be835b60602cd29c', 'https://videos.pexels.com/video-files/20325563/20325563-hd_1280_720_60fps.mp4', 'Content of Lesson 4.1'),
(4, 'Lesson 4.2', 'Description of Lesson 4.2', 'https://img.freepik.com/free-photo/young-asian-woman-lying-floor-home-with-laptop-with-small-pet-dog-beside_1098-20173.jpg?w=996&t=st=1717081476~exp=1717082076~hmac=43059ab343b9c0c945fea435e354d65b9d1dd07b5add7069be835b60602cd29c', 'https://videos.pexels.com/video-files/20325563/20325563-hd_1280_720_60fps.mp4', 'Content of Lesson 4.2');

-- Insert lessons for Course 5
INSERT INTO Lessons (CourseId, Name, Description, Photo, Video, [Content])
VALUES
(5, 'Lesson 5.1', 'Description of Lesson 5.1', 'https://img.freepik.com/free-photo/young-asian-woman-lying-floor-home-with-laptop-with-small-pet-dog-beside_1098-20173.jpg?w=996&t=st=1717081476~exp=1717082076~hmac=43059ab343b9c0c945fea435e354d65b9d1dd07b5add7069be835b60602cd29c', 'https://videos.pexels.com/video-files/20325563/20325563-hd_1280_720_60fps.mp4', 'Content of Lesson 5.1'),
(5, 'Lesson 5.2', 'Description of Lesson 5.2', 'https://img.freepik.com/free-photo/young-asian-woman-lying-floor-home-with-laptop-with-small-pet-dog-beside_1098-20173.jpg?w=996&t=st=1717081476~exp=1717082076~hmac=43059ab343b9c0c945fea435e354d65b9d1dd07b5add7069be835b60602cd29c', 'https://videos.pexels.com/video-files/20325563/20325563-hd_1280_720_60fps.mp4', 'Content of Lesson 5.2'),
(5, 'Lesson 5.3', 'Description of Lesson 5.3', 'https://img.freepik.com/free-photo/young-asian-woman-lying-floor-home-with-laptop-with-small-pet-dog-beside_1098-20173.jpg?w=996&t=st=1717081476~exp=1717082076~hmac=43059ab343b9c0c945fea435e354d65b9d1dd07b5add7069be835b60602cd29c', 'https://videos.pexels.com/video-files/20325563/20325563-hd_1280_720_60fps.mp4', 'Content of Lesson 5.3');

-- Insert into certificates table
INSERT INTO Certificates(name)
VALUES 
('IELTS'),
('TOEIC'),
('TOEFL'),
('Cambridge English'),
('PTE Academic');

