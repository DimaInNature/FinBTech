--
-- Returns intervals for identical IDs.
--

WITH DateIntervals AS (
  SELECT
    Id,
    Dt AS StartDate,
    LEAD(Dt) OVER (PARTITION BY Id ORDER BY Dt) AS EndDate
  FROM Dates
)
SELECT
  Id,
  StartDate AS Sd,
  EndDate AS Ed
FROM DateIntervals
WHERE EndDate IS NOT NULL;