USE DBDACS;

-- Init Teacher
INSERT INTO dbo.AspNetUsers (Id, FirstName, LastName, IsActive, DateBirth, Address, City, PhoneNumber, Description, Photo, AccessFailedCount, EmailConfirmed, PhoneNumberConfirmed, LockoutEnabled, TwoFactorEnabled)
VALUES (1 ,'John', 'Doe', 1, '1990-05-15', '123 Main St', 'New York', '123-456-7890', 'Experienced English tutor specializing in grammar and conversation practice.', 'john_doe.jpg', 0, 0, 0, 0, 1),
(2 ,'Jane', 'Smith', 1, '1985-08-20', '456 Elm St', 'Los Angeles', '987-654-3210', 'Certified ESL instructor with 5+ years of teaching experience.', 'jane_smith.jpg', 0, 0, 0, 0, 1),
(3 ,'David', 'Johnson', 1, '1982-03-10', '789 Oak St', 'Chicago', '555-123-4567', 'Native English speaker with a passion for helping students improve their language skills.', 'david_johnson.jpg', 0, 0, 0, 0, 1),
(4 ,'Emily', 'Brown', 1, '1987-11-25', '321 Pine St', 'San Francisco', '111-222-3333', 'TEFL-certified instructor offering personalized English lessons for all levels.', 'emily_brown.jpg', 0, 0, 0, 0, 1),
(5 ,'Michael', 'Wilson', 1, '1980-09-08', '555 Maple St', 'Seattle', '444-555-6666', 'Experienced English teacher specializing in business English and exam preparation.', 'michael_wilson.jpg', 0, 0, 0, 0, 1),
(6 ,'Sarah', 'Taylor', 1, '1983-06-30', '777 Cedar St', 'Boston', '777-888-9999', 'Passionate about helping students build confidence in speaking English.', 'sarah_taylor.jpg', 0, 0, 0, 0, 1),
(7 ,'Robert', 'Martinez', 1, '1975-12-15', '888 Walnut St', 'Miami', '101-202-3030', 'Interactive lessons focused on practical language skills for everyday situations.', 'robert_martinez.jpg', 0, 0, 0, 0, 1),
(8 ,'Jennifer', 'Lopez', 1, '1978-04-05', '999 Birch St', 'Houston', '404-505-6060', 'Dedicated to helping students achieve their language learning goals.', 'jennifer_lopez.jpg', 0, 0, 0, 0, 1),
(9 ,'Christopher', 'Garcia', 1, '1989-02-20', '222 Oak St', 'Phoenix', '707-808-9090', 'Dynamic and engaging lessons tailored to each student�s needs and interests.', 'christopher_garcia.jpg', 0, 0, 0, 0, 1),
(10 ,'Amanda', 'Hernandez', 1, '1984-07-10', '333 Pine St', 'Philadelphia', '999-888-7777', 'Patient and supportive tutor committed to student success.', 'amanda_hernandez.jpg', 0, 0, 0, 0, 1);
-- Set Role = Teacher:
INSERT INTO dbo.AspNetUserRoles(UserId, RoleId)
VALUES ('1', 'e99c30c8-0d07-4fa5-a528-fbf604ce8dd7'),
('2', 'e99c30c8-0d07-4fa5-a528-fbf604ce8dd7'),
('3', 'e99c30c8-0d07-4fa5-a528-fbf604ce8dd7'),
('4', 'e99c30c8-0d07-4fa5-a528-fbf604ce8dd7'),
('5', 'e99c30c8-0d07-4fa5-a528-fbf604ce8dd7'),
('6', 'e99c30c8-0d07-4fa5-a528-fbf604ce8dd7'),
('7', 'e99c30c8-0d07-4fa5-a528-fbf604ce8dd7'),
('8', 'e99c30c8-0d07-4fa5-a528-fbf604ce8dd7'),
('9', 'e99c30c8-0d07-4fa5-a528-fbf604ce8dd7'),
('10', 'e99c30c8-0d07-4fa5-a528-fbf604ce8dd7');
