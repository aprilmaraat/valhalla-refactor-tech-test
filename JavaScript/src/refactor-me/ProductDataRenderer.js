function ProductDataRenderer() { }

ProductDataRenderer.prototype.render = function () {
	var items = ProductDataConsolidator.get();
	var itemsInEuros = ProductDataConsolidator.getInEuros();
	var itemsInUSDollar = ProductDataConsolidator.getInUSDollars();
	document.getElementById("nzdProducts").innerHTML = ProductDataRenderer.generateHtml('NZD', items);
	document.getElementById("euProducts").innerHTML = ProductDataRenderer.generateHtml('USD', itemsInEuros);
	document.getElementById("usdProducts").innerHTML = ProductDataRenderer.generateHtml('Euro', itemsInUSDollar);
}

ProductDataRenderer.generateHtml = function (currency, itemList) {
	let data = '';
	itemList.forEach(item => {
		data += `<tr>
			<td>${item.name}</td>
			<td>${item.price}</td>
			<td>${item.type}</td>
		</tr>`;
	});

	let html = `<table class="table table-striped table-dark">
		<thead>
			<tr><td colspan="3">Products (${currency})</td></tr>
			<tr>
				<td>Name</td>
				<td>Price</td>
				<td>Type</td>
			</tr>
		</thead>
		<tbody>
		${ data }
		</tbody>
	</table>`;

	return html;
}