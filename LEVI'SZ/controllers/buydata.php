<?php  if ( ! defined('BASEPATH')) exit('No direct script access allowed');

class Buydata extends CI_Controller 
{
    public function index()
    {
       
        $this->load->view("header"); 
        $this->load->view("banner");
        $this->load->view("content_basket_member");  
        
		
		/*if ($this->input->post("szml") == 1)
		{
			$data='<label for="szmlnev">
			<span>Sz�ml�z�si n�v:<span><br>
            <input type="input" id="szmlnev" name="szmlnev" />
			</label><br>
			<label for="szmlcim">
            <span>Sz�ml�z�si c�m:<span><br>
            <input type="input" id="szmlcim" name="szmlcim" />
			</label><br>';
			
			//$this->session->set_userdata($data);
			/*
			$this->load->library('mpdf');
			$this->mpdf->WriteHTML('<p>Hello There</p>');
			$this->mpdf->Output('szamla.pdf');
	
	
			$html = $this->load->view('/pdf_views/order_view',$data, TRUE);
			$this->mpdf->WriteHTML($html);
			$this->mpdf->Output();
	
            redirect("buydata", $data);
				
        }
		
		*/
		$this->load->view("sidebar"); 
        $this->load->view("footer"); 
			
	}
		
}