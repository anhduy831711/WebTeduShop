(function (app) {
    app.filter('statusFilter', function () {
        return function(input)
        {
            if(input)
            {
                return 'Kích Hoạt';
            }
            else
            {
                return 'Khóa';
            }
        }
    })
})(angular.module('tedushop.common'));