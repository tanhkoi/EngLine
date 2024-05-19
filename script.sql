USE DBDACS;
-- Insert into tests table
INSERT INTO tests (id, title)
VALUES (1, 'Sample Test 1'),
    (2, 'Sample Test 2');
-- Insert into questions table
INSERT INTO questions (id, content, TestId)
VALUES (1, 'What is the capital of France?', 1),
    (2, 'What is 2 + 2?', 1),
    (3, 'Who wrote "Hamlet"?', 2),
    (4, 'What is the boiling point of water?', 2);
-- Insert into answer_options table
INSERT INTO AnswerOptions(id, content, QuestionId, IsCorrectOption)
VALUES (1, 'Paris', 1, 1),
    (2, 'London', 1, 0),
    (3, 'Berlin', 1, 0),
    (4, 'Madrid', 1, 0),
    (5, '3', 2, 0),
    (6, '4', 2, 1),
    (7, '5', 2, 0),
    (8, '6', 2, 0),
    (9, 'William Shakespeare', 3, 1),
    (10, 'Charles Dickens', 3, 0),
    (11, 'Mark Twain', 3, 0),
    (12, 'Jane Austen', 3, 0),
    (13, '90°C', 4, 0),
    (14, '100°C', 4, 1),
    (15, '110°C', 4, 0),
    (16, '120°C', 4, 0);