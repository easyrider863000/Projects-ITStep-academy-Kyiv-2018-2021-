<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class Employee extends Model
{
    protected $primaryKey = 'id';
    protected $table = 'emps';
    protected $fillable = [
        'emp_name', 'image_path', 'birth_day', 'gender', 'nation', 
        'country', 'notes', 'pos_id', 'salary', 'created_at', 'updated_at'
    ];
}
