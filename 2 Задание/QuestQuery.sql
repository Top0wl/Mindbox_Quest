select p.Name as �������, c.Name as ���������
from Products p
left join ProductCategories pc on pc.ProductId = p.Id
left join Categories c on pc.CategoryId = c.Id