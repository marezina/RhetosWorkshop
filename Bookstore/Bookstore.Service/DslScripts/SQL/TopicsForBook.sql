SELECT
    b.ID,
    NumberOfTopics = COUNT(t.ID)
FROM
    Bookstore.Book b
    LEFT JOIN Bookstore.BookTopic t ON t.BookID = b.ID
GROUP BY
    b.ID