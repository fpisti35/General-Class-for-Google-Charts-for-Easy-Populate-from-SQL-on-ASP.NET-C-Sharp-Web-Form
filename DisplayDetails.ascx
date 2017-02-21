<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DisplayDetails.ascx.cs" Inherits="WebUserControl" %>


<!-- modal popup window -->
<div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">                
                <h4 class="modal-title" id="modalTitle">Details</h4>
            </div>
            <div class="modal-body">
                <fieldset>
                    <label id="lblMessage" ></label>                      
                 </fieldset>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>                
            </div>
        </div>
    </div>
</div>
<!-- end popup window -->

<script src="/Scripts/js/DisplayDetails.js"></script>