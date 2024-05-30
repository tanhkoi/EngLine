USE DBDACS;
DBCC CHECKIDENT ('Tests', RESEED, 0);
DBCC CHECKIDENT ('Questions', RESEED, 0);
DBCC CHECKIDENT ('AnswerOptions', RESEED, 0);
-- Insert into tests table
INSERT INTO Tests (Title, TimeLimit)
VALUES ('Sample Test 1', '2024-05-20 10:00:00'),
    ('Sample Test 2', '2024-05-20 11:00:00');
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