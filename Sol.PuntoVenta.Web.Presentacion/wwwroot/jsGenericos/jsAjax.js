function Ajax(dataString, urlString) {


    function Post() {

        return new Promise((resolve, reject) => {
            $.ajax({

                // Our sample url to make request
                url: urlString,

                // Type of Request
                type: "POST",
                // Models
                data: dataString,
                dataType: "json",
                contentType: 'application/json',
                // Function to call when to
                // request is ok
                success: function (response) {
                    resolve(response)

                },
                // Error handling
                error: function (error) {
                    console.log(`Error ${error}`);
                    reject(error)
                }, beforeSend: function () {

                    $('#mainloader').addClass('d-none');

                }
            });

        });
    }
    function Get()
    {

        return new Promise((resolve, reject) => {
            $.ajax({
                url: urlString,
                type: "GET",
                async: true,
                success: function (response) {
                    resolve(response)

                },
                // Error handling
                error: function (error) {
                    console.log(`Error ${error}`);
                    reject(error)
                }, beforeSend: function () {
                    $('#mainloader').addClass('d-none');
                }
            });

        });
    }

    function Put()
    {
        return new Promise((resolve, reject) => {
            $.ajax({

                // Our sample url to make request
                url: urlString,

                // Type of Request
                type: "PUT",
                // Models
                data: dataString,
                dataType: "json",
                contentType: 'application/json',
                // Function to call when to
                // request is ok
                success: function (response) {
                    resolve(response)

                },
                // Error handling
                error: function (error) {
                    console.log(`Error ${error}`);
                    reject(error)
                }, beforeSend: function () {

                    $('#mainloader').addClass('d-none');

                }
            });

        });
    }

    function Delete() {
        return new Promise((resolve, reject) => {
            $.ajax({

                // Our sample url to make request
                url: urlString,

                // Type of Request
                type: "DELETE",
                // Models
                data: dataString,
                dataType: "json",
                contentType: 'application/json',
                // Function to call when to
                // request is ok
                success: function (response) {
                    resolve(response)

                },
                // Error handling
                error: function (error) {
                    console.log(`Error ${error}`);
                    reject(error)
                }, beforeSend: function () {

                    $('#mainloader').addClass('d-none');

                }
            });

        });
    }

    return {
        Post: function () {
            return Post();
        },
        Get: function ()
        {
            return Get();
        },
        Put: function ()
        {
            return Put(); 
        }
        ,
        Delete: function () {
            return Delete();
        }

    }
}

