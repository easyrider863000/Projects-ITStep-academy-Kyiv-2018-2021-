<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class Department extends Model
{
    protected $primaryKey = 'id';
    protected $table = 'deps';
    protected $fillable = ['dep_name', 'created_at', 'updated_at'];
}
