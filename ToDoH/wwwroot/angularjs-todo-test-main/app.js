angular.module('todoApp', [])
    .controller('TodoController', ['$scope', '$http', function ($scope, $http) {

        $scope.todos = [];
        $scope.newTodo = '';

        // Load todos from the server
        function loadTodos() {
            $http.get('/Todos/GetTodos').then(function (response) {
                $scope.todos = response.data;
            });
        }

        loadTodos();

        // Add a new todo
        $scope.addTodo = function () {
            if (!$scope.newTodo.trim()) return;

            var todo = {
                title: $scope.newTodo,
                completed: false
            };

            $http.post('/Todos/AddTodo', todo).then(function (response) {
                $scope.todos.push(response.data);
                $scope.newTodo = '';
            });
        };

        // Remove a todo
        $scope.removeTodo = function (index) {
            var id = $scope.todos[index].id;

            $http.post('/Todos/DeleteTodo?id=' + id).then(function (response) {
                if (response.data.success) {
                    $scope.todos.splice(index, 1);
                }
            });
        };

        // Get count of completed todos
        $scope.getCompletedCount = function () {
            return $scope.todos.filter(t => t.completed).length;
        };

        // Get count of remaining (incomplete) todos
        $scope.getRemainingCount = function () {
            return $scope.todos.filter(t => !t.completed).length;
        };

        $scope.toggleCompleted = function (todo) {
            $http.post('/Todos/ToggleCompleted?id=' + todo.id + '&completed=' + todo.completed)
                .then(function (response) {
                    var idx = $scope.todos.findIndex(t => t.id === todo.id);
                    if (idx !== -1) {
                        $scope.todos[idx] = response.data;
                    }
                });
        };

        $scope.toggleAll = function () {
            var allCompleted = $scope.todos.every(t => t.completed);
            $scope.todos.forEach(function (todo) {
                var newStatus = !allCompleted;
                $http.post('/Todos/SetCompletion?id=' + todo.id + '&completed=' + newStatus).then(function (response) {
                    var idx = $scope.todos.findIndex(t => t.id === todo.id);
                    if (idx !== -1) {
                        $scope.todos[idx] = response.data;
                    }
                });
            });
        };


        $scope.clearCompleted = function () {
            var completed = $scope.todos.filter(t => t.completed);

            completed.forEach(function (todo) {
                $http.post('/Todos/MarkIncomplete?id=' + todo.id).then(function (response) {
                    var idx = $scope.todos.findIndex(t => t.id === todo.id);
                    if (idx !== -1) {
                        $scope.todos[idx] = response.data;
                    }
                });
            });

        };


    }]);
