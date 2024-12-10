<div dir="rtl">

# نکته 
چنانچه میخواهید برای query های خود Paging, Filterning, Ordering فعال کنید، query شما باید از کلاس BaseQueryFiltering ارثبری کرده باشد.
و در QueryRepository باید از ExtensionMethod های کتابخانه Gridify استفاده کنید.

به عنوان مثال:

<div dir="ltr">

``` csharp
		return DbContext.Posts.ToPostQueryResult()//manual mapping
			.ApplyPaging(query.Page, query.PageSize)
			.ApplyFiltering(query.Filter)
			.ApplyOrdering(query.OrderBy)
			.ToListAsync(cancellationToken);
```

</div>

برای Filtering و مشاهده اپراتورهای شرطی به لینک زیر مراجعه کنید:
https://alirezanet.github.io/Gridify/guide/filtering

برای Ordering و مشاهده مثال آن به لینک زیر مراجعه کنید:
https://alirezanet.github.io/Gridify/guide/ordering



</div>