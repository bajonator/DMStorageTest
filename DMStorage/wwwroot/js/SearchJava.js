//document.addEventListener("DOMContentLoaded", function () {
//    var searchInput = document.getElementById('searchInput');
//    var context = document.querySelector("body");
//    var instance = new Mark(context);

//    searchInput.addEventListener("input", function () {
//        if (searchInput.value.trim() === "") {
//            instance.unmark();
//        }
//    });
//});
//function searchText(event) {
//    event.preventDefault();
//    var searchInput = document.getElementById('searchInput').value.trim();
//    if (searchInput === "") {
//        return;
//    }

//    var context = document.querySelector("body");
//    var instance = new Mark(context);
//    instance.unmark({
//        done: function () {
//            instance.mark(searchInput);
//        }
//    });
//}

