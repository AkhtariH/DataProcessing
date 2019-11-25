<?php

//Questions: 
//DB Layout ok?
//Should it be able to create, update and delete?


class Product{

    
    private $connection;

    
    private $table_name = "product";

    public $id;
    public $sku;
    public $name;
    public $price;
    public $quantity;
    public $minquantity;
    public $createdAt;
    public $updatedAt;
    public $familyid;
    public $locationid;

    public function __construct($connection){
        $this->connection = $connection;
    }

    
    public function create(){
        $query = "INSERT INTO product(name, price) VALUES (?, ?)";

        $stmt = $this->connection->prepare($query);

        $stmt->execute([$this->name, $this->price]);

        return $stmt;
    }
    
    public function read(){
        $query = "SELECT c.name as family_name, p.id, p.sku, p.name, p.price, p.quantity , p.minquantity, p.createdAt, p.updatedAt FROM " . $this->table_name . " p LEFT JOIN family c ON p.familyid = c.id ORDER BY p.createdAt DESC";

        $stmt = $this->connection->prepare($query);

        $stmt->execute();

        return $stmt;
    }
  
    public function update(){

    }
   
    public function delete(){

    }
}

?>