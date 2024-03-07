Source: https://zaidesanton.substack.com/p/the-most-underrated-skill-sql-for?utm_source=oneoneone
```
CREATE TABLE deals (
  deal_id INT PRIMARY KEY,
  deal_amount DECIMAL(10, 2),
  customer_name VARCHAR(255),
  region VARCHAR(255),
  deal_date DATE 
);
```

# Select biggest deal in each region
## Bad
```
SELECT *
FROM deals d1
WHERE d1.deal_amount = (
    SELECT MAX(d2.deal_amount)
    FROM deals d2
    WHERE d2.region = d1.region
);
```
The subquery is referencing a column from the outer query (d1.region). This dependency typically requires the subquery to be executed once for each row in the outer table, which can be very slow.
## Good
```
WITH max_deals_by_region AS (
  SELECT region, MAX(deal_amount) AS max_deal_amount
  FROM deals
  GROUP BY region
)
SELECT d.*
FROM deals d
JOIN max_deals_by_region rmd ON d.region = rmd.region AND d.deal_amount = rmd.max_deal_amount;
```
Use CTEs defined by WITH clause. When using CTEs, you cannot fall into the correlated subquery trap, it forces you to think of the correct way to solve the problem.

# Select the top 3 deals in each region
Make use of PARTITION BY.

```
WITH ranked_deals AS (
  SELECT
    deal_id, deal_amount, customer_name, region, deal_date,
    RANK() OVER (PARTITION BY region ORDER BY deal_amount DESC) AS deal_rank
  FROM deals
)
SELECT deal_id, deal_amount, customer_name, region, deal_date
FROM  ranked_deals
WHERE deal_rank <= 3
ORDER BY region, deal_rank;
```
- RANK() is a window function. Window functions allow us to perform calculations across a set of rows that are related to the current row.
- To create that related set of rows we use the PARTITION BY keyword, which divides the dataset into groups.
- The ORDER BY command allows us to order the rows inside each group.

For instance, RANK() OVER (PARTITION BY region) assigns a rank within each region, with the rows in each region being treated as a separate group. While "partition by" groups the data, the "window function" (like RANK) performs the calculation across these groups.