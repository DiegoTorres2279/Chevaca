# bootstrap-confirm
Modal dialog confirmation and message based on bootstrap v3.

### Use
```javascript
$.confirm({
	message: 'want to delete this id?',
	onOk: function() { // callback if confirmed

	},
	onCancel: function() { // callback if close
	
	}
});
```

### Show simple message
```javascript
$.confirm({
	title: 'Success!',
	titleIcon: 'glyphicon glyphicon-ok',
	template: 'success',
	message: 'id has been deleted!',
	buttonOk: false,
	buttonCancel: false
});
```

### Default Options
```javascript
$.confirm.defaults = {
	message: '',									// Message (string)
	buttonOk: true,									// Ok button displays (boolean)
	buttonCancel: true,								// Cancel button displays (boolean)
	template: 'danger',								// Modal theme (string) [success, info, warning, danger, default]
	title: 'Confirma',								// Modal title (string)
	titleIcon: 'glyphicon glyphicon-question-sign',	// Icon title (string)
	labelOk: 'Sim',									// Ok button's label (string)
	labelCancel: 'Cancelar',						// Cancel button's label (string)
	templateOk: 'danger',							// Ok button theme (string) [success, info, warning, danger, default]
	templateCancel: 'default'						// Cancel button theme (string) [success, info, warning, danger, default]
};
```
