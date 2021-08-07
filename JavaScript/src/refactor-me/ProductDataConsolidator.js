function ProductDataConsolidator() { }

ProductDataConsolidator.get = function () {
	return ProductDataConsolidator.generateProductList();
}

ProductDataConsolidator.getInUSDollars = function () {
	return ProductDataConsolidator.generateProductList(0.76);
}

ProductDataConsolidator.getInEuros = function () {
	return ProductDataConsolidator.generateProductList(0.67);
}

ProductDataConsolidator.generateProductList = function (currencyMultiplier = 1) {
	let lawnmowers = new LawnmowerRepository().getAll();
	let phoneCases = new PhoneCaseRepository().getAll();
	let tShirts = new TShirtRepository().getAll();
	let products = [];

	lawnmowers.forEach(item => {
		products.push({
			id: item.id,
			name: item.name,
			price: item.price * currencyMultiplier,
			type: "Lawnmower"
		});
	});
	phoneCases.forEach(item => {
		products.push({
			id: item.id,
			name: item.name,
			price: item.price * currencyMultiplier,
			type: "Phone Case"
		});
	});
	tShirts.forEach(item => {
		products.push({
			id: item.id,
			name: item.name,
			price: item.price * currencyMultiplier,
			type: "T-Shirt"
		});
	});

	return products;
}
