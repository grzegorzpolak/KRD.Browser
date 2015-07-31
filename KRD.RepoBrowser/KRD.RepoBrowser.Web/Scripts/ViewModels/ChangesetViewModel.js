
var ChangesetViewModel = (function() {

  function ChangesetViewModel(changesetFilter) {
    var _this = this;
    this.Filter = changesetFilter;
    this.Changesets = ko.observableArray([]);

    this.gridOptions = {
      data: _this.Changesets,
      showGroupPanel: true,
      columnDefs: [{ field: 'timestamp', displayName: 'Data' },
        { field: 'username', displayName: 'Użytkownik' },
        { field: 'branchName', displayName: 'Gałąź' },
        { field: 'repositoryName', displayName: 'Repozytorium' }]
    };

    this.getChangesets = function() {
      var model = ko.toJSON(_this.Filter);
      $.ajax({
        type: 'POST',
        contentType: 'application/json',
        url: '/api/changeset',
        data: model
      }).done(function(data) {
        _this.Changesets(data);

        var calendarData;

   
        for (var i = 0; i < data.length; i++) {
          calendarData[data[i][timestamp]] = data.groupBy

          
        }

        //calendarData["34535345"] = 5;
      });
    };
  }
  
  return ChangesetViewModel;

})();