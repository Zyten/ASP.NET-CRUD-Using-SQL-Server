<div class="container">
	<div class="alert alert-info">
    <strong>Simple CRUD by Sean & Ruban</strong></a>
	</div>
</div>

<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery/1.12.3/jquery.js"></script>
<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.3.0/js/bootstrap.min.js"></script>

<script type="text/javascript">
	$(document).ready (function(){
            $("#success-alert").hide();
	});
	function fadeAlert() { {
		$("#success-alert").fadeTo(2000, 500).slideUp(500, function(){
	    $("#success-alert").alert('close');
		});   
	});
</script>
</body>
</html>
