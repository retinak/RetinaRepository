if (typeof JsActions == 'undefined') {
    var JsActions = {};
    JsActions.WebApi = {};
}
JsActions.LookupType = {
    getLookups: function (LookupTypeId, options) { ///<param name="LookupTypeId" type = "Guid"></param>
        ///<param name="options" type="ajaxSettings">[OPTIONAL] AjaxOptions partial object; it will be mergend with the one sent to .ajax jQuery function</param><returns type="jqXHR"/>
    }
};
if (typeof Guid == 'undefined') {
    function Guid() {}
}
