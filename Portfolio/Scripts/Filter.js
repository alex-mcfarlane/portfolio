/**
 * 
 * @param {string} filterId The Id of the filter list
 * @param {string} elemClass The class of filterable items
 */
function Filter(filterId, itemsClass) {
    this.filter = $('#' + filterId);
    this.items = $('.' + itemsClass);
    this.filterBtns = [];
    this.filterableItems = [];

    this.initItems(itemsClass);
    this.initBtns();
    this.addClickHandler();
}

Filter.prototype.initItems = function (itemsClass) {
    var items = $('.' + itemsClass);
    
    for (var i = 0; i < items.length; i++) {
        this.filterableItems.push($(items[i]));
    }
}

Filter.prototype.initBtns = function () {
    var btns = this.filter.find('li');
    
    for (var i = 0; i < btns.length; i++) {
        var btn = $(btns[i]);
        this.filterBtns[btn.data('category-id')] = btn;
    }
}

Filter.prototype.addClickHandler = function () {
    for (var key in this.filterBtns) {
        var btn = this.filterBtns[key];
        var self = this;

        btn.click(self.filterBtnClickHandler(key));
    }
}

Filter.prototype.filterBtnClickHandler = function (filterItemClass) {
    var self = this;
    return function () {
        self.items.fadeOut(); console.log(filterItemClass);

        setTimeout(function () {
            // show only items that have the class of the clicked buttons identifier
            self.filterableItems.forEach(function (item) {
                if (item.hasClass(filterItemClass)) {
                    item.fadeIn();
                }
            });
        }, 300);
    }
}