<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

class CreateTables extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::create('deps', function (Blueprint $table) {
            $table->id();
            $table->string('dep_name', 100)->unique();
            $table->timestamps();
        });

        Schema::create('poss', function (Blueprint $table) {
            $table->id();
            $table->string('pos_name', 100);
            $table->foreignId('dep_id')->references('id')->on('deps');
            $table->timestamps();
        });

        Schema::create('emps', function (Blueprint $table) {
            $table->id();
            $table->string('emp_name', 100);
            $table->string('image_path', 256)->nullable();
            $table->date('birth_day')->nullable();
            $table->string('gender', 50)->nullable();
            $table->string('nation', 50)->nullable();
            $table->string('country', 50)->nullable();
            $table->string('notes', 512)->nullable();
            $table->foreignId('pos_id')->references('id')->on('poss');
            $table->double('salary')->nullable();
            $table->timestamps();
        });
    }

    /**
     * Reverse the migrations.
     *
     * @return void
     */
    public function down()
    {
        Schema::dropIfExists('deps');
        Schema::dropIfExists('poss');
        Schema::dropIfExists('emps');
    }
}
