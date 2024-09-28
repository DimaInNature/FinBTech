--
-- Returns a list of clients with more than 2 contacts.
--

SELECT c.ClientName
FROM Clients c
JOIN ClientContacts cc ON c.Id = cc.ClientId
GROUP BY c.ClientName
HAVING COUNT(cc.Id) > 2;