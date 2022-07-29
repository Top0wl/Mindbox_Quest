select p.Name as Продукт, c.Name as Категория
from Products p
left join ProductCategories pc on pc.ProductId = p.Id
left join Categories c on pc.CategoryId = c.Id