(function ($) {
    var model = [
        { name: "Archie", address: "1, a road, a town, a county, a postcode", tel: "1234567890", site: "www.aurl.com", pic: "/img/john.jpg", deleteMe: function () { viewModel.people.remove(this); } },
        { name: "Andy", address: "1, a road, a town, a county, a postcode", tel: "1234567890", site: "www.aurl.com", pic: "/img/john.jpg", deleteMe: function () { viewModel.people.remove(this); } },
        { name: "Bernard", address: "1, a road, a town, a county, a postcode", tel: "1234567890", site: "www.aurl.com", pic: "/img/john.jpg", deleteMe: function () { viewModel.people.remove(this); } },
        { name: "Ben", address: "1, a road, a town, a county, a postcode", tel: "1234567890", site: "www.aurl.com", pic: "/img/john.jpg", deleteMe: function () { viewModel.people.remove(this); } },
        { name: "Chris", address: "1, a road, a town, a county, a postcode", tel: "1234567890", site: "www.aurl.com", pic: "/img/john.jpg", deleteMe: function () { viewModel.people.remove(this); } },
        { name: "Charles", address: "1, a road, a town, a county, a postcode", tel: "1234567890", site: "www.aurl.com", pic: "/img/john.jpg", deleteMe: function () { viewModel.people.remove(this); } },
        { name: "Dermot", address: "1, a road, a town, a county, a postcode", tel: "1234567890", site: "www.aurl.com", pic: "/img/john.jpg", deleteMe: function () { viewModel.people.remove(this); } },
        { name: "David", address: "1, a road, a town, a county, a postcode", tel: "1234567890", site: "www.aurl.com", pic: "/img/john.jpg", deleteMe: function () { viewModel.people.remove(this); } },
        { name: "Englebert", address: "1, a road, a town, a county, a postcode", tel: "1234567890", site: "www.aurl.com", pic: "/img/john.jpg", deleteMe: function () { viewModel.people.remove(this); } },
        { name: "Erwin", address: "1, a road, a town, a county, a postcode", tel: "1234567890", site: "www.aurl.com", pic: "/img/john.jpg", deleteMe: function () { viewModel.people.remove(this); } },
        { name: "Fred", address: "3, an avenue, a village, a county, a postcode", tel: "1234567890", site: "www.aurl.com", pic: "/img/fred.jpg", deleteMe: function () { viewModel.people.remove(this); } },
        { name: "Freda", address: "4, a street, a suburb, a county, a postcode", tel: "1234567890", site: "www.aurl.com", pic: "/img/jane.jpg", deleteMe: function () { viewModel.people.remove(this); } },
        { name: "Gerald", address: "4, a street, a suburb, a county, a postcode", tel: "1234567890", site: "www.aurl.com", pic: "/img/jane.jpg", deleteMe: function () { viewModel.people.remove(this); } },
        { name: "Gemma", address: "3, an avenue, a village, a county, a postcode", tel: "1234567890", site: "www.aurl.com", pic: "/img/fred.jpg", deleteMe: function () { viewModel.people.remove(this); } },
        { name: "Henry", address: "4, a street, a suburb, a county, a postcode", tel: "1234567890", site: "www.aurl.com", pic: "/img/jane.jpg", deleteMe: function () { viewModel.people.remove(this); } },
        { name: "Harold", address: "4, a street, a suburb, a county, a postcode", tel: "1234567890", site: "www.aurl.com", pic: "/img/jane.jpg", deleteMe: function () { viewModel.people.remove(this); } },
        { name: "Ivor", address: "4, a street, a suburb, a county, a postcode", tel: "1234567890", site: "www.aurl.com", pic: "/img/jane.jpg", deleteMe: function () { viewModel.people.remove(this); } },
        { name: "Ian", address: "4, a street, a suburb, a county, a postcode", tel: "1234567890", site: "www.aurl.com", pic: "/img/jane.jpg", deleteMe: function () { viewModel.people.remove(this); } },
        { name: "John", address: "1, a road, a town, a county, a postcode", tel: "1234567890", site: "www.aurl.com", pic: "/img/john.jpg", deleteMe: function () { viewModel.people.remove(this); } },
        { name: "Jane", address: "2, a street, a city, a county, a postcode", tel: "1234567890", site: "www.aurl.com", pic: "/img/jane.jpg", deleteMe: function () { viewModel.people.remove(this); } },

    ],
    viewModel = {
        people: ko.observableArray(model),
        displayButton: ko.observable(true),
        displayForm: ko.observable(false),
        showForm: function () {
            this.displayForm(true).displayButton(false);
        },
        hideForm: function () {
            this.displayForm(false).displayButton(true);
        },
        addPerson: function () {
            this.displayForm(false).displayButton(true).people.push({
                name: $("#name").val(),
                address: $("#address").val(),
                tel: $("#tel").val(),
                site: $("#site").val(),
                pic: "",
                deleteMe: function () { viewModel.people.remove(this); }
            });
        },
        currentPage: ko.observable(0),
        pageSize: ko.observable(5),
        navigate: function (e) {
            var el = e.target;

            if (el.id === "next") {
                if (this.currentPage() < ko.utils.unwrapObservable(this.totalPages()) - 1) {
                    this.currentPage(this.currentPage() + 1);
                }
            } else {
                if (this.currentPage() > 0) {
                    this.currentPage(this.currentPage() - 1);
                }
            }
        }
    };

    //paging
    viewModel.totalPages = ko.dependentObservable(function () {
        return Math.ceil(ko.utils.unwrapObservable(this.people).length / this.pageSize());
    }, viewModel);

    viewModel.showCurrentPage = ko.dependentObservable(function () {
        if (this.currentPage() > this.totalPages()) {
            this.currentPage(this.totalPages() - 1);
        }
        var startIndex = this.pageSize() * this.currentPage();
        return this.people.slice(startIndex, startIndex + this.pageSize());
    }, viewModel);

    viewModel.numericPageSize = ko.dependentObservable(function () {
        if (typeof (this.pageSize()) !== "number") {
            this.pageSize(parseInt(this.pageSize()));
        }
    }, viewModel);

    ko.applyBindings(viewModel);
})(jQuery);