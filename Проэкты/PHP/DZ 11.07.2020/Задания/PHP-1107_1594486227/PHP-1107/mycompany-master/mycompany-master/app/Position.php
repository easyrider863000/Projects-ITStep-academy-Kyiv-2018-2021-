<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class Position extends Model
{
    protected $primaryKey = 'id';
    protected $table = 'poss';
    protected $fillable = ['pos_name', 'dep_id', 'created_at', 'updated_at'];
}
